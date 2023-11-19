using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;
using SamGK_Api.Models.Schedule;

namespace SamGK_Api.Controllers;

public class ScheduleController : _BaseController, ISсheduleController
{
    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IEmployee entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{entity.Id}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IGroup entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/{entity.Id}/{date.ToString("yyyy-MM-dd")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, ICab entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{entity.name.Replace(@"/", "_")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }
}