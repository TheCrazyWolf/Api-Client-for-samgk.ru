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

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(
        DateOnly startDate,
        DateOnly endDate,
        ScheduleSearchType type,
        string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true,
        bool overrideCache = false,
        int delay = 700)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        List<IResultOutScheduleFromDate> resultOutScheduleFromDates = [];
        var currentDate = startDate;

        while (currentDate <= endDate)
        {
            var schedule = await GetScheduleAsync(currentDate, type, id, scheduleCallType, showImportantLessons, showRussianHorizonLesson, overrideCache);

            if (schedule.Lessons.Any())
            {
                resultOutScheduleFromDates.Add(schedule);
            }

            currentDate = currentDate.AddDays(1);

            if (delay > 0)
            {
                await Task.Delay(delay).ConfigureAwait(false);
            }
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

    public async Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(
        DateOnly date,
        ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true,
        bool overrideCache = false,
        int delay = 700)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        var cache = getCacheByType(type);

        List<IResultOutScheduleFromDate> result = [];

        foreach (var item in cache)
        {
            var id = getIdByType(type, item);
            var scheduleFromDate = await GetScheduleAsync(date, type, id,
                scheduleCallType: scheduleCallType,
                showImportantLessons: showImportantLessons,
                showRussianHorizonLesson: showRussianHorizonLesson,
                overrideCache: overrideCache);

            if (scheduleFromDate.Lessons.Count > 0)
            {
                result.Add(scheduleFromDate);
            }
        }

        return result;
    }

    // Возвращает соответствующий кеш в зависимости от типа поиска
    IEnumerable<object> getCacheByType(ScheduleSearchType type) => type switch
    {
        ScheduleSearchType.Employee => IdentityCache.Select(x => x.Object),
        ScheduleSearchType.Cab => CabsCache.Select(x => x.Object),
        ScheduleSearchType.Group => GroupsCache.Select(x => x.Object),
        _ => throw new ArgumentException($"Unsupported ScheduleSearchType: {type}", nameof(type)),
    };

    // Возвращает идентификатор для элемента кеша
    string getIdByType(ScheduleSearchType type, object item) => type switch
    {
        ScheduleSearchType.Employee => ((IResultOutIdentity)item).Id.ToString(),
        ScheduleSearchType.Cab => ((IResultOutCab)item).Adress,
        ScheduleSearchType.Group => ((IResultOutGroup)item).Id.ToString(),
        _ => throw new ArgumentException($"Unsupported ScheduleSearchType: {type}", nameof(type)),
    };


    public IList<IResultOutScheduleFromDate> GetAllSchedule(DateOnly date, ScheduleSearchType type,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true, bool showRussianHorizonLesson = true, bool overrideCache = false, int delay = 700)
    {
        return GetAllScheduleAsync(date, type, ScheduleCallType.Standart, showImportantLessons,
                showRussianHorizonLesson, delay: delay, overrideCache: overrideCache)
            .GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(
        DateOnly date,
        ScheduleSearchType type,
        string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true,
        bool overrideCache = false)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        if (!overrideCache && ExtractFromScheduleCache(date, type, id) is IResultOutScheduleFromDate cache) // Пытаемся извлечь данные из кэша
        {
            return cache;
        }

        var url = GetScheduleUrl(date, type, id);
        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url).ConfigureAwait(false);

        var newSchedule = ParseScheduleResult(date, result, type, id, scheduleCallType, showImportantLessons, showRussianHorizonLesson);

        if (!overrideCache) // Сохранение данных в кэш, чтобы не напригать лишний раз сайт СГК
        {
            SaveToCache(newSchedule, determineCacheLifeTime(newSchedule.Date));
        }

        return newSchedule;
    }

    int determineCacheLifeTime(DateOnly scheduleDate) // Код просто лучшее читается
    {
        return scheduleDate < DateOnly.FromDateTime(DateTime.Now)
            ? DefaultLifeTimeInMinutesLong
            : DefaultLifeTimeInMinutesShort;
    }


    const string UrlDateSGK = "https://mfc.samgk.ru/schedule/api/get-rasp?date=";

    string GetScheduleUrl(DateOnly date, ScheduleSearchType type, string id)
    {
        //return type switch // Хотя можно и так, но я люблю изобретать велосипед
        //{
        //    ScheduleSearchType.Employee => $"{UrlDateSGK}{date:yyyy-MM-dd}&teacher={id}",
        //    ScheduleSearchType.Group => $"{UrlDateSGK}{date:yyyy-MM-dd}&group={id}",
        //    ScheduleSearchType.Cab => $"{UrlDateSGK}{date:yyyy-MM-dd}&cab={id}",
        //    _ => throw new ArgumentOutOfRangeException()
        //};

        var queryParams = new Dictionary<ScheduleSearchType, string>
        {
            { ScheduleSearchType.Employee, "teacher" },
            { ScheduleSearchType.Group, "group" },
            { ScheduleSearchType.Cab, "cab" }
        };

        if (!queryParams.TryGetValue(type, out var queryParam))
        {
            throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported ScheduleSearchType");
        }

        return $"{UrlDateSGK}{date:yyyy-MM-dd}&{queryParam}={id}";
    }

    // О господи, это что-то страшное
    //private IResultOutScheduleFromDate ParseScheduleResult(DateOnly date,
    //    Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result, ScheduleSearchType searchType, string id,
    //    ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
    //    bool showImportantLessons = true, bool showRussianHorizonLesson = true)
    //{
    //    var returnableResult = new ResultOutResultOutScheduleFromDate { Date = date, SearchType = searchType, IdValue = id };
    //    // костыль чтобы по умолчанию включены внеурочка, тогда юзаем сдвигаем расписание
    //    if ((showImportantLessons || showRussianHorizonLesson) &&
    //        scheduleCallType == ScheduleCallType.Standart && (date.DayOfWeek == DayOfWeek.Monday ||
    //                                                          date.DayOfWeek == DayOfWeek.Thursday &&
    //                                                          date.Month != 6 && date.Month != 7))
    //    {
    //        scheduleCallType = ScheduleCallType.StandartWithShift;
    //    }
    //    returnableResult.CallType = scheduleCallType;

    //    if (result is null || result.Count == 0) return returnableResult;

    //    foreach (var array in result.Values)
    //    {
    //        foreach (var arrayScheduleItem in array)
    //        {
    //            foreach (var scheduleItem in arrayScheduleItem.Value)
    //            {
    //                var lesson = new ResultOutResultOutLesson
    //                {
    //                    NumPair = scheduleItem.Pair,
    //                    NumLesson = scheduleItem.Number,
    //                    Durations = scheduleItem.GetDurationLessonDetails(scheduleCallType),
    //                    SubjectDetails = new ResultOutSubject
    //                    {
    //                        Id = scheduleItem.DisciplineInfo.Id,
    //                        SubjectName = scheduleItem.DisciplineName,
    //                        Index = $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
    //                        IsAttestation = scheduleItem.Zachet == 1,
    //                    },
    //                    EducationGroup = ExtractGroupFromCache(scheduleItem.Group)
    //                };

    //                AddTeachersToLesson(scheduleItem, lesson);
    //                AddCabsToLesson(scheduleItem, lesson);

    //                returnableResult.Lessons.Add(lesson);
    //            }
    //        }
    //    }

    //    returnableResult.Lessons = returnableResult.Lessons.RemoveDuplicates().SortByLessons();
    //    return AddAdditionalLessons(date, returnableResult, showImportantLessons, showRussianHorizonLesson);
    //}

    IResultOutScheduleFromDate ParseScheduleResult(
        DateOnly date,
        Dictionary<string, Dictionary<string, List<ScheduleItem>>>? result,
        ScheduleSearchType searchType,
        string id,
        ScheduleCallType scheduleCallType = ScheduleCallType.Standart,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true)
    {
        var returnableResult = new ResultOutResultOutScheduleFromDate
        {
            Date = date,
            SearchType = searchType,
            IdValue = id,
            CallType = determineScheduleCallType(date, scheduleCallType, showImportantLessons, showRussianHorizonLesson)
        };

        if (result == null || result.Count == 0)
            return returnableResult;

        // Обработка расписания
        foreach (var scheduleItem in result.Values.SelectMany(array => array.Values).SelectMany(items => items))
        {
            var lesson = createLesson(scheduleItem, returnableResult.CallType);
            returnableResult.Lessons.Add(lesson);
        }

        // Удаление дубликатов, сортировка и то сё
        returnableResult.Lessons = returnableResult.Lessons
            .RemoveDuplicates()
            .SortByLessons();

        return AddAdditionalLessons(date, returnableResult, showImportantLessons, showRussianHorizonLesson);
    }

    // Определение типа звонков
    ScheduleCallType determineScheduleCallType(
        DateOnly date,
        ScheduleCallType scheduleCallType,
        bool showImportantLessons,
        bool showRussianHorizonLesson)
    {
        if ((showImportantLessons || showRussianHorizonLesson) &&
            scheduleCallType == ScheduleCallType.Standart &&
            (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday) &&
            date.Month is not (6 or 7))
        {
            return ScheduleCallType.StandartWithShift;
        }
        return scheduleCallType;
    }

    // Создание объекта урока
    ResultOutResultOutLesson createLesson(ScheduleItem scheduleItem, ScheduleCallType scheduleCallType)
    {
        var lesson = new ResultOutResultOutLesson
        {
            NumPair = scheduleItem.Pair,
            NumLesson = scheduleItem.Number,
            Durations = scheduleItem.GetDurationLessonDetails(scheduleCallType),
            SubjectDetails = new ResultOutSubject
            {
                Id = scheduleItem.DisciplineInfo.Id,
                SubjectName = scheduleItem.DisciplineName,
                Index = $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
                IsAttestation = scheduleItem.Zachet == 1
            },
            EducationGroup = ExtractFromGroupCache(scheduleItem.Group)
        };

        AddTeachersToLesson(scheduleItem, lesson);
        AddCabsToLesson(scheduleItem, lesson);

        return lesson;
    }


    void AddTeachersToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
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


    void AddCabsToLesson(ScheduleItem scheduleItem, ResultOutResultOutLesson lesson)
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

    //private IResultOutScheduleFromDate AddAdditionalLessons(DateOnly date, IResultOutScheduleFromDate returnableResult,
    //    bool showImportantLessons = true, bool showRussianHorizonLesson = true) // Это прям очень что-то страшное
    //{
    //    var firstLesson = returnableResult.Lessons.FirstOrDefault();

    //    // Разговоры о важном
    //    if (showImportantLessons && (firstLesson != null && (firstLesson.NumPair == 1 && firstLesson.NumLesson == 1 ||
    //                                                         firstLesson.NumPair == 1 && firstLesson.NumLesson == 0)
    //                                                     && date.DayOfWeek == DayOfWeek.Monday && date.Month != 6 &&
    //                                                     date.Month != 7))
    //    {
    //        returnableResult.Lessons = returnableResult.Lessons.AddTalkImportantLesson().SortByLessons();
    //    }

    //    // россия мои горизонты
    //    if (showRussianHorizonLesson && (firstLesson?.EducationGroup?.Course == 1
    //                                     && (firstLesson.NumPair == 1 && firstLesson.NumLesson == 1 ||
    //                                         firstLesson.NumPair == 1 && firstLesson.NumLesson == 0)
    //                                     && date.DayOfWeek == DayOfWeek.Thursday && date.Month != 6 && date.Month != 7))
    //    {
    //        returnableResult.Lessons = returnableResult.Lessons.AddRussianMyHorizonTalk().SortByLessons();
    //    }

    //    return returnableResult;
    //}
    IResultOutScheduleFromDate AddAdditionalLessons( // Проверить
        DateOnly date,
        IResultOutScheduleFromDate returnableResult,
        bool showImportantLessons = true,
        bool showRussianHorizonLesson = true)
    {
        var firstLesson = returnableResult.Lessons.FirstOrDefault();

        bool IsLessonAtFirstPair() =>
            firstLesson != null && (firstLesson.NumPair == 1 && (firstLesson.NumLesson == 1 || firstLesson.NumLesson == 0));

        bool IsSummerMonth() => date.Month == 6 || date.Month == 7;

        // Разговоры о важном
        if (showImportantLessons && IsLessonAtFirstPair() && date.DayOfWeek == DayOfWeek.Monday && !IsSummerMonth())
        {
            returnableResult.Lessons = returnableResult.Lessons
                .AddTalkImportantLesson()
                .SortByLessons();
        }

        // Россия мои горизонты
        if (showRussianHorizonLesson && firstLesson?.EducationGroup?.Course == 1 && IsLessonAtFirstPair()
            && date.DayOfWeek == DayOfWeek.Thursday && !IsSummerMonth())
        {
            returnableResult.Lessons = returnableResult.Lessons
                .AddRussianMyHorizonTalk()
                .SortByLessons();
        }

        return returnableResult;
    }
}