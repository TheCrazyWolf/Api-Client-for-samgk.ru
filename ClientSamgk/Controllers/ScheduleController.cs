using ClientSamgk.Common;
using ClientSamgk.Enums;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Utils;
using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Controllers;

public class ScheduleController : CommonSamgkController, ISсheduleController
{
    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutIdentity entity)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString()).GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutIdentity entity)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Employee, entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutIdentity entity,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutGroup entity)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
            entity.Id.ToString()).GetAwaiter().GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutGroup entity)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Group,
            entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutGroup entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutGroup entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Group,
            entity.Id.ToString(), delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutCab entity)
    {
        return GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
            entity.Adress).GetAwaiter().GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutCab entity)
    {
        return await GetScheduleAsync(date: date, type: ScheduleSearchType.Cab,
            entity.Adress);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutCab entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
            entity.Adress, delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutCab entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: ScheduleSearchType.Cab,
            entity.Adress, delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, string id)
    {
        return GetScheduleAsync(date: date, type: type, id: id).GetAwaiter().GetResult();
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type,
        string id, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay).GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, string id)
    {
        await ConfiguringCache();
        
        var url = type switch
        {
            ScheduleSearchType.Employee => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&teacher={id}",
            ScheduleSearchType.Group => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&group={id}",
            ScheduleSearchType.Cab => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&cab={id}",
            _ => ""
        };

        var returenableResult = new ResultOutResultOutScheduleFromDate
        {
            Date = date
        };
        
        try
        {
            var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url);
            
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
                            DurationStart = scheduleItem.GetStartLessonTime(returenableResult.Date),
                            DurationEnd = scheduleItem.GetEndLessonTime(returenableResult.Date),
                            SubjectDetails = new ResultOutSubject
                            {
                                Id = scheduleItem.DisciplineInfo.Id,
                                SubjectName = scheduleItem.DisciplineName,
                                Index = $"{scheduleItem.DisciplineInfo.IndexName}.{scheduleItem.DisciplineInfo.IndexNum}",
                                IsAttestation = scheduleItem.Zachet is 1,
                            },
                            EducationGroup = CachesGroups.First(x => x.Id == scheduleItem.Group)
                        };
                        
                        foreach (var idTeacher in scheduleItem.Teacher)
                            lesson.Identity.Add(CachedIdentities.First(x => x.Id == idTeacher));

                        foreach (var idCab in scheduleItem.Cab)
                            lesson.Cabs.Add(CachesCabs.First(x => x.Adress == idCab));

                        returenableResult.Lessons.Add(lesson);
                    }
                }
            
            }

            returenableResult.Lessons = returenableResult.Lessons.RemoveDuplicates().SortByLessons();
            
            var firstLesson = returenableResult.Lessons.FirstOrDefault();

            // если есть 1 пара (или 1 урок) и это понедельник
            if (firstLesson is not null 
                && (firstLesson.NumPair is 1 && firstLesson.NumLesson is 1 || firstLesson.NumPair is 1 && firstLesson.NumLesson is 0) 
                && returenableResult.Date.DayOfWeek is DayOfWeek.Monday && returenableResult.Date.Month != 6 && returenableResult.Date.Month != 7)
            {
                returenableResult.Lessons = returenableResult.Lessons.AddTalkImportantLesson().SortByLessons();
            }
            
            // если 1 пара по четвергам
            // и это первый курс добавляем россия мои горизонты
            if (firstLesson?.EducationGroup.Course is 1
                && (firstLesson.NumPair is 1 && firstLesson.NumLesson is 1 || firstLesson.NumPair is 1 && firstLesson.NumLesson is 0)
                && returenableResult.Date.DayOfWeek is DayOfWeek.Thursday && returenableResult.Date.Month != 6 && returenableResult.Date.Month != 7)
            {
                returenableResult.Lessons = returenableResult.Lessons.AddRussianMyHorizonTalk().SortByLessons();
            }

            
        }
        catch 
        {
            return returenableResult;
        }
        
        return returenableResult;
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        ScheduleSearchType type, string id, int delay = 700)
    
    {
        await ConfiguringCache();
        var resultOutScheduleFromDates = new List<IResultOutScheduleFromDate>();
        endDate = endDate.AddDays(1);

        while (startDate != endDate)
        {
            var outScheduleFromDate = await GetScheduleAsync(date: startDate, type: type, id: id);

            if (outScheduleFromDate.Lessons.Any())
                resultOutScheduleFromDates.Add(outScheduleFromDate);

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return resultOutScheduleFromDates;
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnly date, ScheduleSearchType type, int delay = 700)
    {
        await ConfiguringCache();
        
        var result = new List<IResultOutScheduleFromDate>();
        
        if(type is ScheduleSearchType.Employee)
            foreach (var item in CachedIdentities)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Employee, item.Id.ToString());
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }
        
        if(type is ScheduleSearchType.Cab)
            foreach (var item in CachesCabs)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Cab, item.Adress);
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }
        
        if(type is ScheduleSearchType.Group)
            foreach (var item in CachesGroups)
            {
                var scheduleFromDate = await GetScheduleAsync(date, ScheduleSearchType.Group, item.Id.ToString());
                if (scheduleFromDate.Lessons.Count != 0)
                    result.Add(scheduleFromDate);
            }

        return result;
    }

    public IList<IResultOutScheduleFromDate> GetAllSchedule(DateOnly date, ScheduleSearchType type, int delay = 700)
    {
        return GetAllScheduleAsync(date, type, delay).GetAwaiter().GetResult();
    }
}