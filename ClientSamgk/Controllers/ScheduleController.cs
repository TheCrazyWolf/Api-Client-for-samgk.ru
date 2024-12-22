using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgk.Utils;
using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Controllers;

public class ScheduleController : CommonSamgkController, ISсheduleController
{
    private readonly Uri _scheduleApiEndpointUri = new ("https://mfc.samgk.ru/schedule/api/get-rasp");

    {
    }

    {



    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, string id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)

    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        var resultOutScheduleFromDates = new List<IResultOutScheduleFromDate>();
        endDate = endDate.AddDays(1);

        while (startDate != endDate)
        {
            var outScheduleFromDate = await GetScheduleAsync(date: startDate, type: type, id: id,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
            if (outScheduleFromDate.Lessons.Any()) resultOutScheduleFromDates.Add(outScheduleFromDate);
            startDate = startDate.AddDays(1);
            await Task.Delay(delay);
        }

        return resultOutScheduleFromDates;

    public async Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        var result = new List<IResultOutScheduleFromDate>();

        switch (type)
        {
            case ScheduleSearchType.Employee:
            {
                foreach (var item in IdentityCache.Select(x=> x.Object))
                {
                    var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Employee, item.Id.ToString(),
                        scheduleCallType: scheduleCallType,
                        showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
                    if (scheduleFromDate.Lessons.Count != 0)
                        result.Add(scheduleFromDate);
                }

                break;
            }
            case ScheduleSearchType.Cab:
            {
                foreach (var item in CabsCache.Select(x=> x.Object))
                {
                    var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Cab, item.Adress,
                        scheduleCallType: scheduleCallType,
                        showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
                    if (scheduleFromDate.Lessons.Count != 0)
                        result.Add(scheduleFromDate);
                }

                break;
            }
            case ScheduleSearchType.Group:
            {
                foreach (var item in GroupsCache.Select(x=> x.Object))
                {
                    var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Group, item.Id.ToString(),
                        scheduleCallType: scheduleCallType,
                        showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
                    if (scheduleFromDate.Lessons.Count != 0)
                        result.Add(scheduleFromDate);
                }

                break;
            }
        }

        return result;
    }

    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    private Uri GetScheduleUrl(ScheduleQuery query)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        if (!overrideCache)
        {
            var cachedItem = ExtractFromCache(date, type, id);
            if (cachedItem != null) return cachedItem;
        }
        
        var url = GetScheduleUrl(date, type, id);
        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url);
        var newSchedule = ParseScheduleResult(date, result, type, id, scheduleCallType, showImportantLessons, showRussianHorizonLesson);
        if(!overrideCache) SaveToCache(newSchedule, (newSchedule.Date < DateOnly.FromDateTime(DateTime.Now.Date) ? DefaultLifeTimeInMinutesLong : DefaultLifeTimeInMinutesShort));
        return newSchedule;
    }
        ArgumentNullException.ThrowIfNull(query.SearchId);

    {
        return query.SearchType switch
        {
            ScheduleSearchType.Employee => new Uri(_scheduleApiEndpointUri, $"?date={query.Date:yyyy-MM-dd}&teacher={query.SearchId}"),
            ScheduleSearchType.Group => new Uri(_scheduleApiEndpointUri,$"?date={query.Date:yyyy-MM-dd}&group={query.SearchId}"),
            ScheduleSearchType.Cab => new Uri(_scheduleApiEndpointUri,$"?date={query.Date:yyyy-MM-dd}&cab={query.SearchId}"),
            _ => throw new ArgumentOutOfRangeException(nameof(query.SearchType))
        };
    }

    private IResultOutScheduleFromDate ParseScheduleResult(DateOnly date,
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result, ScheduleQuery query)
    {
        var returnableResult = new ResultOutResultOutScheduleFromDate
            { Date = date, SearchType = query.SearchType, IdValue = query.SearchId! };
        // костыль чтобы по умолчанию включены внеурочка, тогда юзаем сдвигаем расписание
        if ((query.ShowImportantLessons || query.ShowRussianHorizonLesson) &&
            query.ScheduleCallType == ScheduleCallType.Standart && (date.DayOfWeek == DayOfWeek.Monday ||
                                                              date.DayOfWeek == DayOfWeek.Thursday &&
                                                              date.Month != 6 && date.Month != 7))
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
                        Durations = scheduleItem.GetDurationLessonDetails(query.ScheduleCallType),
                        SubjectDetails = new ResultOutSubject
                        {
                            Id = scheduleItem.DisciplineInfo.Id,
                            SubjectName = scheduleItem.DisciplineName,
                            Index = $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
                            IsAttestation = scheduleItem.Zachet == 1,
                        },
                        EducationGroup = ExtractGroupFromCache(scheduleItem.Group)
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
                     .Select(idTeacher => IdentityCache.Select(x => x.Object).FirstOrDefault(x => x.Id == idTeacher))
                     .OfType<IResultOutIdentity>())
        {
            lesson.Identity.Add(itemTeacher);
        }
    }

    private void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemCab in scheduleItem.Cab
                     .Select(idCab => CabsCache.Select(x => x.Object).FirstOrDefault(x => x.Adress == idCab))
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