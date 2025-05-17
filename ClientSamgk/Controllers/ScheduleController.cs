using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgk.Models.Api.Implementation.Education;
using ClientSamgk.Models.Api.Implementation.Schedule;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using ClientSamgk.Models.Api.Mfc.Shedules;
using ClientSamgk.Models.Enums.Schedule;
using ClientSamgk.Models.Params.Interfaces.Cache;
using ClientSamgk.Utils;
using RestSharp;

namespace ClientSamgk.Controllers;

public class ScheduleController(
    CacheManager<IResultOutIdentity> teachersCacheManager,
    CacheManager<IResultOutGroup> groupsCacheManager,
    CacheManager<IResultOutCab> cabsCacheManager,
    ICache<IResultOutScheduleFromDate> schedulesCache,
    ICacheOptions cacheOptions,
    RestClient client
) : ISсheduleController
{
    private readonly Uri _scheduleApiEndpointUri = new("https://mfc.samgk.ru/schedule/api/get-rasp");

    public IList<IResultOutScheduleFromDate> GetSchedule(ScheduleQuery query)
    {
        return GetScheduleAsync(query).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(ScheduleQuery query,
        CancellationToken cToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        await teachersCacheManager.EnsureCacheAsync(cToken).ConfigureAwait(false);
        await groupsCacheManager.EnsureCacheAsync(cToken).ConfigureAwait(false);
        await cabsCacheManager.EnsureCacheAsync(cToken).ConfigureAwait(false);
        schedulesCache.CleanupCache();

        var dates = query.StartDate.HasValue && query.EndDate.HasValue
            ? DateTimeUtils.GetDateRange(query.StartDate.Value, query.EndDate.Value)
            : query.Date.HasValue
                ? [query.Date.Value]
                : throw new ArgumentException("Query must contains any date or range of dates");

        var ids = query.WithAllForType
            ? query.SearchType switch
            {
                ScheduleSearchType.Employee => teachersCacheManager.Data.Select(x => x.Object.Id.ToString())
                    .AsEnumerable(),
                ScheduleSearchType.Group => groupsCacheManager.Data.Select(x => x.Object.Id.ToString()).ToList(),
                ScheduleSearchType.Cab => cabsCacheManager.Data.Select(x => x.Object.Adress).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(query.SearchType))
            }
#pragma warning disable CS8601 // Possible null reference assignment.
            : [query.SearchId];
#pragma warning restore CS8601 // Possible null reference assignment.

        var resultFromDates = await dates
            .SelectMany(date => ids.Select(id => (date, id)))
            .LoopAsyncResult<(DateOnly, string), IResultOutScheduleFromDate>(async pair =>
                await RequestSchedule(query, pair.Item1, pair.Item2, cToken).ConfigureAwait(false));

        return resultFromDates.ToList();
    }

    private async Task<IResultOutScheduleFromDate> RequestSchedule(ScheduleQuery query, DateOnly date, string id,
        CancellationToken cToken = default)
    {
        if (!query.OverrideCache)
        {
            //var cachedItem = ExtractFromCache(date, query.SearchType, id);
            var cachedItem = schedulesCache
                .ExtractFromCache(x => x.Date == date && x.SearchType == query.SearchType && x.IdValue == id);
            if (cachedItem != null) return cachedItem;
        }

        var url = GetScheduleUrl(query.SearchType, date, id);
        var result = await client
            .SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url, cToken: cToken)
            .ConfigureAwait(false);
        var newSchedule = ParseScheduleResult(date, result, query);
        if (!query.OverrideCache)
            schedulesCache.SaveToCache(newSchedule,
                newSchedule.Date < DateOnly.FromDateTime(DateTime.Now.Date)
                    ? cacheOptions.LifeTimeObjectsForLong
                    : cacheOptions.LifeTimeObjectsForShort);

        if (query.Delay > 0)
            await Task.Delay(query.Delay, cToken).ConfigureAwait(false);

        return newSchedule;
    }

    private Uri GetScheduleUrl(ScheduleSearchType searchType, DateOnly date, string id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return searchType switch
        {
            ScheduleSearchType.Employee => new Uri(_scheduleApiEndpointUri,
                $"?date={date:yyyy-MM-dd}&teacher={id}"),
            ScheduleSearchType.Group => new Uri(_scheduleApiEndpointUri, $"?date={date:yyyy-MM-dd}&group={id}"),
            ScheduleSearchType.Cab => new Uri(_scheduleApiEndpointUri, $"?date={date:yyyy-MM-dd}&cab={id}"),
            _ => throw new ArgumentOutOfRangeException(nameof(searchType))
        };
    }

    private IResultOutScheduleFromDate ParseScheduleResult(DateOnly date,
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result, ScheduleQuery query)
    {
        var returnableResult = new ResultOutResultOutScheduleFromDate
            { Date = date, SearchType = query.SearchType, IdValue = query.SearchId! };
        // костыль чтобы по умолчанию включены внеурочка, тогда юзаем сдвигаем расписание
        if ((query.ShowImportantLessons || query.ShowRussianHorizonLesson) &&
            query.ScheduleCallType == ScheduleCallType.Standart
            && (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday
                && date.Month != 6 && date.Month != 7))
            returnableResult.CallType = ScheduleCallType.StandartWithShift;
        else
            returnableResult.CallType = query.ScheduleCallType;

        if (result is null || result.Count == 0) return returnableResult;

        foreach (var array in result.Values)
        {
            foreach (var arrayScheduleItem in array)
            {
                foreach (var scheduleItem in arrayScheduleItem.Value)
                {
                    var lesson = new ResultOutResultOutLesson
                    {
                        NumPair = scheduleItem.Pair,
                        NumLesson = scheduleItem.Number,
                        Durations = scheduleItem.GetDurationLessonDetails(returnableResult.CallType),
                        SubjectDetails = new ResultOutSubject
                        {
                            Id = scheduleItem.DisciplineInfo.Id,
                            SubjectName = scheduleItem.DisciplineName,
                            Index = $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
                            IsAttestation = scheduleItem.Zachet == 1,
                        },
                        EducationGroup = groupsCacheManager.Cache.ExtractFromCache(x => x.Id == scheduleItem.Group)
                    };

                    AddTeachersToLesson(scheduleItem, lesson);
                    AddCabsToLesson(scheduleItem, lesson);

                    returnableResult.Lessons.Add(lesson);
                }
            }
        }

        returnableResult.Lessons = returnableResult.Lessons.RemoveDuplicates().SortByLessons();
        return AddAdditionalLessons(date, returnableResult, query.ShowImportantLessons, query.ShowRussianHorizonLesson);
    }

    private void AddTeachersToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemTeacher in scheduleItem.Teacher
                     .Select(idTeacher =>
                         teachersCacheManager.Data.Select(x => x.Object).FirstOrDefault(x => x.Id == idTeacher))
                     .OfType<IResultOutIdentity>())
        {
            lesson.Identity.Add(itemTeacher);
        }
    }

    private void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemCab in scheduleItem.Cab.Select(idCab =>
                         cabsCacheManager.Data.Select(x => x.Object).FirstOrDefault(x => x.Adress == idCab))
                     .OfType<IResultOutCab>())
        {
            lesson.Cabs.Add(itemCab);
        }
    }

    private IResultOutScheduleFromDate AddAdditionalLessons(DateOnly date, IResultOutScheduleFromDate returnableResult,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        var firstLesson = returnableResult.Lessons.FirstOrDefault();

        var isFirstPair = firstLesson is { NumPair: 1, NumLesson: 1 } or { NumPair: 1, NumLesson: 0 };
        var isNotInJuneJuly = date.Month != 6 && date.Month != 7;

        // Разговоры о важном
        if (showImportantLessons
            && isFirstPair
            && date.DayOfWeek == DayOfWeek.Monday
            && isNotInJuneJuly)
        {
            returnableResult.Lessons = returnableResult.Lessons.AddTalkImportantLesson().SortByLessons();
        }

        // россия мои горизонты
        if (showRussianHorizonLesson
            && firstLesson?.EducationGroup?.Course == 1
            && isFirstPair
            && date.DayOfWeek == DayOfWeek.Thursday
            && isNotInJuneJuly)
        {
            returnableResult.Lessons = returnableResult.Lessons.AddRussianMyHorizonTalk().SortByLessons();
        }

        return returnableResult;
    }
}