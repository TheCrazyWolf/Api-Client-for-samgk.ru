using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgk.Utils;
using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Controllers;

public class ScheduleController : CommonSamgkController, ISсheduleController
{
    private readonly Uri _scheduleApiEndpointUri = new("https://mfc.samgk.ru/schedule/api/get-rasp");

    /// <inheritdoc />
    public IList<IResultOutScheduleFromDate> GetSchedule(ScheduleQuery query) =>
        GetScheduleAsync(query).GetAwaiter().GetResult();

    /// <inheritdoc />
    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(ScheduleQuery query,
        CancellationToken cToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        await UpdateIfCacheIsOutdated(cToken).ConfigureAwait(false);

        IList<DateOnly> dates = query switch
        {
            { StartDate: not null, EndDate: not null } => DateTimeUtils.GetDateRange(query.StartDate.Value,
                query.EndDate.Value),
            { Date: not null } => [query.Date.Value],
            _ => throw new ArgumentException("Query must contain a date or a range of dates")
        };

        IEnumerable<string> ids = query.WithAllForType
            ? query.SearchType switch
            {
                ScheduleSearchType.Employee => IdentityCache.Select(x => x.Object.Id.ToString()),
                ScheduleSearchType.Group => GroupsCache.Select(x => x.Object.Id.ToString()),
                ScheduleSearchType.Cab => CabsCache.Select(x => x.Object.Adress),
                _ => throw new ArgumentOutOfRangeException(nameof(query.SearchType))
            } : [query.SearchId ?? throw new ArgumentException("Query must contain any search id")];

        var resultFromDates = await dates
            .SelectMany(date => ids.Select(id => (date, id)))
            .LoopAsyncResult<(DateOnly, string), IResultOutScheduleFromDate>(async pair =>
                await RequestSchedule(query, pair.Item1, pair.Item2, cToken).ConfigureAwait(false));

        return resultFromDates.ToList();
    }


    private async Task<IResultOutScheduleFromDate> RequestSchedule(ScheduleQuery query, DateOnly date, string id,
        CancellationToken cToken = default)
    {
        if (!query.OverrideCache
            && ExtractFromScheduleCache(date, query.SearchType, id) is { } cachedItem)
            return cachedItem;

        var url = GetScheduleUrl(query.SearchType, date, id);

        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url, cToken: cToken)
            .ConfigureAwait(false);

        var newSchedule = ParseScheduleResult(date, result, query);

        if (!query.OverrideCache)
        {
            SaveToCache(newSchedule, newSchedule.Date < DateOnly.FromDateTime(DateTime.Now.Date)
                ? DefaultLifeTimeInMinutesLong
                : DefaultLifeTimeInMinutesShort);
        }

        if (query.Delay > 0)
            await Task.Delay(query.Delay, cToken).ConfigureAwait(false);

        return newSchedule;
    }

    private Uri GetScheduleUrl(ScheduleSearchType searchType, DateOnly date, string id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return searchType switch
        {
            ScheduleSearchType.Employee => new Uri(_scheduleApiEndpointUri, $"?date={date:yyyy-MM-dd}&teacher={id}"),
            ScheduleSearchType.Group => new Uri(_scheduleApiEndpointUri, $"?date={date:yyyy-MM-dd}&group={id}"),
            ScheduleSearchType.Cab => new Uri(_scheduleApiEndpointUri, $"?date={date:yyyy-MM-dd}&cab={id}"),
            _ => throw new ArgumentOutOfRangeException(nameof(searchType))
        };
    }

    private IResultOutScheduleFromDate ParseScheduleResult(DateOnly date,
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result, ScheduleQuery query)
    {
        var schedule = new ResultOutResultOutScheduleFromDate(date, query.SearchType, query.SearchId!);

        if (result == null || result.Count == 0) return schedule;

        foreach (var scheduleItem in result.Values.SelectMany(array => array.Values).SelectMany(items => items))
        {
            var lesson = CreateLesson(scheduleItem, schedule.CallType);
            schedule.Lessons.Add(lesson);
        }


        schedule.Lessons = schedule.Lessons.RemoveDuplicates().SortByLessons();

        return AddAdditionalLessons(date, schedule);
    }

    private ResultOutResultOutLesson CreateLesson(ScheduleItem scheduleItem, ScheduleCallType scheduleCallType)
    {
        var lesson = new ResultOutResultOutLesson()
        {
            NumPair = scheduleItem.Pair,
            NumLesson = scheduleItem.Number,
            Durations = scheduleItem.GetDurationLessonDetails(scheduleCallType),
            SubjectDetails = new ResultOutSubject(scheduleItem.DisciplineInfo.Id, scheduleItem.DisciplineName,
                $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
                scheduleItem.Zachet == 1),
            EducationGroup = ExtractFromGroupCache(scheduleItem.Group),
        };

        AddTeachersToLesson(scheduleItem, lesson);
        AddCabsToLesson(scheduleItem, lesson);

        return lesson;
    }

    private void AddTeachersToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        var teachersById = IdentityCache
            .Select(r => r.Object)
            .Where(r => r is IResultOutIdentity)
            .ToDictionary(i => i.Id, x => x);

        foreach (var teacher in scheduleItem.Teacher)
        {
            if (teachersById.TryGetValue(teacher, out var teacherData))
            {
                lesson.Identity.Add(teacherData);
            }
        }
    }

    private void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        var cabsByAddress = CabsCache
            .Select(r => r.Object)
            .Where(r => r is IResultOutCab)
            .ToDictionary(c => c.Adress, x => x);

        foreach (var idCab in scheduleItem.Cab)
        {
            if (cabsByAddress.TryGetValue(idCab, out var cabinetData))
            {
                lesson.Cabs.Add(cabinetData);
            }
        }
    }

    private IResultOutScheduleFromDate AddAdditionalLessons(
        DateOnly date,
        IResultOutScheduleFromDate returnableResult,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true)
    {
        var firstLesson = returnableResult.Lessons.FirstOrDefault();

        var isLessonAtFirstPair = firstLesson is { NumPair: 1, NumLesson: 1 or 0 };
        var isSummerMonth = date.Month is 6 or 7;

        // Разговоры о важном
        if (showImportantLessons
            && isLessonAtFirstPair
            && date.DayOfWeek == DayOfWeek.Monday
            && !isSummerMonth)
        {
            returnableResult.Lessons = returnableResult.Lessons.AddTalkImportantLesson().SortByLessons();
        }

        // Россия мои горизонты
        if (showRussianHorizonLesson
            && firstLesson?.EducationGroup?.Course == 1
            && isLessonAtFirstPair
            && date.DayOfWeek == DayOfWeek.Thursday
            && !isSummerMonth)
        {
            returnableResult.Lessons = returnableResult.Lessons.AddRussianMyHorizonTalk().SortByLessons();
        }

        return returnableResult;
    }
}