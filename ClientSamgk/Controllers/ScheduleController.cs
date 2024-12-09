using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
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
    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutIdentity entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString(), overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutIdentity entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString(), overrideCache: overrideCache);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
                entity.Id.ToString(), delay: delay, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart, bool overrideCache = false,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay, overrideCache: overrideCache);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
                entity.Id.ToString(), overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
            entity.Id.ToString(), overrideCache: overrideCache);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
                entity.Id.ToString(), delay: delay, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutGroup entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
            entity.Id.ToString(), delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart, bool overrideCache = false,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
                entity.Adress, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart, bool overrideCache = false,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
            entity.Adress, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart, bool overrideCache = false,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
                entity.Adress, delay: delay, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutCab entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
            entity.Adress, delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return GetScheduleAsync(date: date, type: type, id: id, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, long id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return GetScheduleAsync(date: date, type: type, id: id.ToString(), scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, long id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        return await GetScheduleAsync(date: date, type: type, id: id.ToString(), scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type,
        string id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type,
        long id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, string id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)

    {
        await UpdateIfCacheIsOutdated();
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
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, long id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id.ToString(),
            delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson, overrideCache: overrideCache);
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false,
        int delay = 700)
    {
        await UpdateIfCacheIsOutdated();

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

    public IList<IResultOutScheduleFromDate> GetAllSchedule(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)
    {
        return GetAllScheduleAsync(date, type, ScheduleCallType.Standart, showImportantLessons,
                showRussianHorizonLesson, delay:delay, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false)
    {
        await UpdateIfCacheIsOutdated();

        if (!overrideCache)
        {
            var cachedItem = ExtractFromCache(date, type, id);
            if (cachedItem != null) return cachedItem;
        }
        
        var url = GetScheduleUrl(date, type, id);
        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url);
        var newSchedule = ParseScheduleResult(date, result, type, id, scheduleCallType, showImportantLessons, showRussianHorizonLesson);
        if (newSchedule.Lessons.Count == 0) return newSchedule;
        if(!overrideCache) SaveToCache(newSchedule, (newSchedule.Date < DateOnly.FromDateTime(DateTime.Now.Date) ? DefaultLifeTimeInMinutesLong : DefaultLifeTimeInMinutesShort));
        return newSchedule;
    }

    private string GetScheduleUrl(DateOnly date, ScheduleSearchType type, string id)
    {
        return type switch
        {
            ScheduleSearchType.Employee => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date:yyyy-MM-dd}&teacher={id}",
            ScheduleSearchType.Group => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date:yyyy-MM-dd}&group={id}",
            ScheduleSearchType.Cab => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date:yyyy-MM-dd}&cab={id}",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private IResultOutScheduleFromDate ParseScheduleResult(DateOnly date,
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result, ScheduleSearchType searchType, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        var returnableResult = new ResultOutResultOutScheduleFromDate { Date = date, SearchType =searchType, IdValue = id};
        if (result is null || result.Count == 0) return returnableResult;

        // костыль чтобы по умолчанию включены внеурочка, тогда юзаем сдвигаем расписание
        if ((showImportantLessons || showRussianHorizonLesson) && 
            scheduleCallType == ScheduleCallType.Standart && (date.DayOfWeek == DayOfWeek.Monday ||
                                                              date.DayOfWeek == DayOfWeek.Thursday && 
                                                              date.Month != 6 && date.Month != 7))
        {
            scheduleCallType = ScheduleCallType.StandartWithShift;
        }
        
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
                        Durations = scheduleItem.GetDurationLessonDetails(scheduleCallType),
                        DurationStart = scheduleItem.GetStartLessonTime(date),
                        DurationEnd = scheduleItem.GetEndLessonTime(date),
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
        return AddAdditionalLessons(date, returnableResult, showImportantLessons, showRussianHorizonLesson);
    }

    private void AddTeachersToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemTeacher in scheduleItem.Teacher
                     .Select(idTeacher => IdentityCache.Select(x=> x.Object).FirstOrDefault(x => x.Id == idTeacher))
                     .OfType<IResultOutIdentity>())
        {
            lesson.Identity.Add(itemTeacher);
        }
    }

    private void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemCab in scheduleItem.Cab
                     .Select(idCab => CabsCache.Select(x=> x.Object).FirstOrDefault(x => x.Adress == idCab))
                     .OfType<IResultOutCab>())
        {
            lesson.Cabs.Add(itemCab);
        }
    }

    private IResultOutScheduleFromDate AddAdditionalLessons(DateOnly date, IResultOutScheduleFromDate returnableResult,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        var firstLesson = returnableResult.Lessons.FirstOrDefault();

        // Разговоры о важном
        if (showImportantLessons && (firstLesson != null && (firstLesson.NumPair == 1 && firstLesson.NumLesson == 1 ||
                                                             firstLesson.NumPair == 1 && firstLesson.NumLesson == 0)
                                                         && date.DayOfWeek == DayOfWeek.Monday && date.Month != 6 &&
                                                         date.Month != 7))
        {
            returnableResult.Lessons = returnableResult.Lessons.AddTalkImportantLesson().SortByLessons();
        }

        // россия мои горизонты
        if (showRussianHorizonLesson && (firstLesson?.EducationGroup?.Course == 1
                                         && (firstLesson.NumPair == 1 && firstLesson.NumLesson == 1 ||
                                             firstLesson.NumPair == 1 && firstLesson.NumLesson == 0)
                                         && date.DayOfWeek == DayOfWeek.Thursday && date.Month != 6 && date.Month != 7))
        {
            returnableResult.Lessons = returnableResult.Lessons.AddRussianMyHorizonTalk().SortByLessons();
        }

        return returnableResult;
    }
}