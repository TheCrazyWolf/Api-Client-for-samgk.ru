using ClientSamgk.Common;
using ClientSamgk.Enums;
using ClientSamgk.Interfaces.Client;
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
        return GetScheduleAsync(date: date, type: SheduleSearchType.Employee, entity.Id.ToString()).GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutIdentity entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Employee, entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutIdentity entity,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IResultOutIdentity entity, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutGroup entity)
    {
        return GetScheduleAsync(date: date, type: SheduleSearchType.Group,
            entity.Id.ToString()).GetAwaiter().GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutGroup entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Group,
            entity.Id.ToString());
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutGroup entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Group,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutGroup entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Group,
            entity.Id.ToString(), delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutCab entity)
    {
        return GetScheduleAsync(date: date, type: SheduleSearchType.Cab,
            entity.Adress).GetAwaiter().GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutCab entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Cab,
            entity.Adress);
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutCab entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Cab,
            entity.Adress, delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutCab entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Cab,
            entity.Adress, delay: delay);
    }

    public IResultOutScheduleFromDate GetSchedule(DateOnly date, SheduleSearchType type, string id)
    {
        return GetScheduleAsync(date: date, type: type, id: id).GetAwaiter().GetResult();
    }

    public IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, SheduleSearchType type,
        string id, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay).GetAwaiter()
            .GetResult();
    }

    public async Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, SheduleSearchType type, string id)
    {
        var url = type switch
        {
            SheduleSearchType.Employee => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&teacher={id}",
            SheduleSearchType.Group => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&group={id}",
            SheduleSearchType.Cab => $"https://mfc.samgk.ru/schedule/api/get-rasp?date={date.ToString("yyyy-MM-dd")}&cab={id}",
            _ => ""
        };

        var returenableResult = new ResultOutResultOutScheduleFromDate();
        var result = await SendRequest<Dictionary<string, Dictionary<string, List<ScheduleItem>>>>(url);

        returenableResult.Date = date;

        foreach (var scheduleItem in result.Values)
        {
            foreach (var resultLessonsApi in scheduleItem)
            {
                foreach (var item in resultLessonsApi.Value)
                {
                    var lesson = new ResultOutResultOutLesson
                    {
                        NumPair = item.Pair,
                        NumLesson = item.Number,
                        SubjectDetails = new ResultOutCabSubject
                        {
                            Id = item.DisciplineInfo.Id,
                            SubjectName =
                                $"{item.DisciplineInfo.IndexName}.{item.DisciplineInfo.IndexNum} {item.DisciplineName}"
                        },
                        EducationGroup = CachesGroups.First(x => x.Id == item.Group)
                    };

                    foreach (var idTeacher in item.Teacher)
                        lesson.Identity.Add(CachedIdentities.First(x => x.Id == idTeacher));

                    foreach (var idCab in item.Cab)
                        lesson.Cabs.Add(CachesCabs.First(x => x.Adress == idCab));

                    returenableResult.Lessons.Add(lesson);
                }
            }
            
        }

        returenableResult.Lessons = returenableResult.Lessons
            .OrderBy(x => x.NumPair) 
            .ThenBy(x => x.NumLesson)
            .ToList();
        
        return returenableResult;
    }

    public async Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        SheduleSearchType type, string id, int delay = 700)
    {
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
}