using ClientSamgk.Common;
using ClientSamgk.Enums;
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
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString())
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutIdentity entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
                entity.Id.ToString(), delay: delay)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
                entity.Id.ToString())
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
            entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutGroup entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
                entity.Id.ToString(), delay: delay)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutGroup entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
            entity.Id.ToString(), delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
                entity.Adress, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
            entity.Adress, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutCab entity,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
                entity.Adress, delay: delay, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutCab entity, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
            entity.Adress, delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: type, id: id, scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, long id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return GetScheduleAsync(date: date, type: type, id: id.ToString(), scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, long id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        return await GetScheduleAsync(date: date, type: type, id: id.ToString(), scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type,
        string id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type,
        long id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, string id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)

    {
        await UpdateIfCacheIsOutdated();
        var resultOutScheduleFromDates = new List<IResultOutScheduleFromDate>();
        endDate = endDate.AddDays(1);

        while (startDate != endDate)
        {
            var outScheduleFromDate = await GetScheduleAsync(date: startDate, type: type, id: id,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
            if (outScheduleFromDate.Lessons.Any()) resultOutScheduleFromDates.Add(outScheduleFromDate);
            startDate = startDate.AddDays(1);
            await Task.Delay(delay);
        }

        return resultOutScheduleFromDates;
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, long id, ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id.ToString(),
            delay: delay, scheduleCallType: scheduleCallType,
            showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true,
        int delay = 700)
    {
        await UpdateIfCacheIsOutdated();

        var result = new List<IResultOutScheduleFromDate>();

        if (type is ScheduleSearchType.Employee)
            foreach (var item in CachedIdentities)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Employee, item.Id.ToString(),
                    scheduleCallType: scheduleCallType,
                    showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }

        if (type is ScheduleSearchType.Cab)
            foreach (var item in CachesCabs)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Cab, item.Adress,
                    scheduleCallType: scheduleCallType,
                    showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }

        if (type is ScheduleSearchType.Group)
            foreach (var item in CachesGroups)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Group, item.Id.ToString(),
                    scheduleCallType: scheduleCallType,
                    showImportantLessons: showImportantLessons, showRussianHorizonLesson: showRussianHorizonLesson);
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }

        return result;
    }

    public IList<IResultOutScheduleFromDate> GetAllSchedule(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, int delay = 700)
    {
        return GetAllScheduleAsync(date, type, ScheduleCallType.Standart, showImportantLessons,
                showRussianHorizonLesson, delay)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        await UpdateIfCacheIsOutdated();
        var url = GetScheduleUrl(date, type, id);
        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url);
        return ParseScheduleResult(date, result, scheduleCallType, showImportantLessons, showRussianHorizonLesson);
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
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    {
        var returnableResult = new ResultOutResultOutScheduleFromDate { Date = date };
        if (result is null || result.Count == 0) return returnableResult;

        if ((showImportantLessons || showRussianHorizonLesson) && 
            scheduleCallType == ScheduleCallType.Standart && (date.DayOfWeek == DayOfWeek.Monday ||
                                                              date.DayOfWeek == DayOfWeek.Thursday && date.Month != 6 && date.Month != 7))
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
                        EducationGroup = CachesGroups.FirstOrDefault(x => x.Id == scheduleItem.Group)
                    };

                    AddTeachersToLesson(scheduleItem, lesson);
                    AddCabsToLesson(scheduleItem, lesson);

                    returnableResult.Lessons.Add(lesson);
                }
            }
        }

        returnableResult.Lessons = returnableResult.Lessons.RemoveDuplicates().SortByLessons();
        return AddCustomLessons(date, returnableResult, showImportantLessons, showRussianHorizonLesson);
    }

    private void AddTeachersToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemTeacher in scheduleItem.Teacher
                     .Select(idTeacher => CachedIdentities.FirstOrDefault(x => x.Id == idTeacher))
                     .OfType<IResultOutIdentity>())
        {
            lesson.Identity.Add(itemTeacher);
        }
    }

    private void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
    {
        foreach (var itemCab in scheduleItem.Cab
                     .Select(idCab => CachesCabs.FirstOrDefault(x => x.Adress == idCab))
                     .OfType<IResultOutCab>())
        {
            lesson.Cabs.Add(itemCab);
        }
    }

    private IResultOutScheduleFromDate AddCustomLessons(DateOnly date, IResultOutScheduleFromDate returnableResult,
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