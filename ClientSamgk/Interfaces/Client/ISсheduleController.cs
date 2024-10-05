using ClientSamgk.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Interfaces.Client;

public interface ISсheduleController
{
    IResultOutScheduleFromDate GetSchedule(DateTime date, IResultOutIdentity entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateTime date, IResultOutIdentity entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateTime startDate, DateTime endDate, IResultOutIdentity entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateTime startDate, DateTime endDate, IResultOutIdentity entity, int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateTime date, IResultOutGroup entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateTime date, IResultOutGroup entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateTime startDate, DateTime endDate, IResultOutGroup entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateTime startDate, DateTime endDate, IResultOutGroup entity, int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateTime date, IResultOutCab entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateTime date, IResultOutCab entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateTime startDate, DateTime endDate, IResultOutCab entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateTime startDate, DateTime endDate, IResultOutCab entity, int delay = 700);
    
    IResultOutScheduleFromDate GetSchedule(DateTime date, ScheduleSearchType type, string id);
    IResultOutScheduleFromDate GetSchedule(DateTime date, ScheduleSearchType type, long id);
    
    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateTime date, ScheduleSearchType type, string id);
    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateTime date, ScheduleSearchType type, long id);
    
    IList<IResultOutScheduleFromDate> GetSchedule(DateTime startDate, DateTime endDate, ScheduleSearchType type, string id, int delay = 700);
    IList<IResultOutScheduleFromDate> GetSchedule(DateTime startDate, DateTime endDate, ScheduleSearchType type, long id, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateTime startDate, DateTime endDate, ScheduleSearchType type, string id, int delay = 700);
    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateTime startDate, DateTime endDate, ScheduleSearchType type, long id, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateTime date, ScheduleSearchType type, int delay = 700);
    IList<IResultOutScheduleFromDate> GetAllSchedule(DateTime date, ScheduleSearchType type, int delay = 700);
}