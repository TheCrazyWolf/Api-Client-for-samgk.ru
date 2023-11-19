using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Controllers;

public class ScheduleController : _BaseController, ISсheduleController
{
    private IEnumerable<IScheduleDate>? Get<IEmployee>(DateOnly date, IEmployee entity)
    {
        var options = new RestRequest($"https://asu.samgk.ru/api/schedule/teacher/2023-11-20/{entity.Id}", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");
        options.AddHeaders()
        return null;
    }
    
    IEnumerable<IScheduleDate>? ISсheduleController.Get<T>(DateOnly date, T entity)
    {
        return Get(date, entity);
    }
}