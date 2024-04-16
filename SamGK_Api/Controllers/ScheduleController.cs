using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;
using SamGK_Api.Models.Schedule;

namespace SamGK_Api.Controllers;

public class ScheduleController : BaseController, ISсheduleController
{
    public IEnumerable<IScheduleDate> GetSchedule(DateOnly date, IEmployee entity)
    {
        return GetScheduleAsync(date: date, type: SheduleSearchType.Employee, entity.Id.ToString()).GetAwaiter()
            .GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, IEmployee entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Employee, entity.Id.ToString());
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, IEmployee entity,
        int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IEmployee entity, int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Employee,
            entity.Id.ToString(), delay: delay);
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly date, IGroup entity)
    {
        return GetScheduleAsync(date: date, type: SheduleSearchType.Group,
            entity.Id.ToString()).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, IGroup entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Group,
            entity.Id.ToString());
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Group,
            entity.Id.ToString(), delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IGroup entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Group,
            entity.Id.ToString(), delay: delay);
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly date, ICab entity)
    {
        return GetScheduleAsync(date: date, type: SheduleSearchType.Cab,
            entity.Name).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, ICab entity)
    {
        return await GetScheduleAsync(date: date, type: SheduleSearchType.Cab,
            entity.Name);
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Cab,
            entity.Name, delay: delay).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, ICab entity,
        int delay = 700)
    {
        return await GetScheduleAsync(startDate: startDate, endDate: endDate, type: SheduleSearchType.Cab,
            entity.Name, delay: delay);
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly date, SheduleSearchType type, string id)
    {
        return GetScheduleAsync(date: date, type: type, id: id).GetAwaiter().GetResult();
    }

    public IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, SheduleSearchType type,
        string id, int delay = 700)
    {
        return GetScheduleAsync(startDate: startDate, endDate: endDate, type: type, id: id, delay: delay).GetAwaiter()
            .GetResult();
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, SheduleSearchType type, string id)
    {
        var url = type switch
        {
            SheduleSearchType.Employee =>
                $"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{id}",
            SheduleSearchType.Group => $"https://asu.samgk.ru/api/schedule/{id}/{date.ToString("yyyy-MM-dd")}",
            SheduleSearchType.Cab =>
                $"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{id}",
            _ => ""
        };

        var options =
            new RestRequest(url);
        options.AddHeaders(GetHeaders());

        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return new List<IScheduleDate>();

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? new List<IScheduleDate>() : new List<IScheduleDate> { obj };
    }

    public async Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        SheduleSearchType type, string id, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var result2 = await GetScheduleAsync(date: startDate, type: type, id: id);
            
            sсheduleList.Add(result2.First());

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return sсheduleList;
    }
}