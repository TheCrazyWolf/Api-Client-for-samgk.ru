using RestSharp;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Controllers;

public class Shedule : _BaseController, ISсheduleController
{
    private IEnumerable<IScheduleDate>? Get<TAccountResult>(DateOnly date, TAccountResult entity)
    {
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");

        return null;
    }
    
    IEnumerable<IScheduleDate>? ISсheduleController.Get<T>(DateOnly date, T entity)
    {
        return Get(date, entity);
    }
}