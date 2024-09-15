using ClientSamgk.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Interfaces.Client;

public interface ISсheduleController
{
    IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutIdentity entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutIdentity entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutIdentity entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutIdentity entity, int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutGroup entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutGroup entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutGroup entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutGroup entity, int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateOnly date, IResultOutCab entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, IResultOutCab entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, IResultOutCab entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IResultOutCab entity, int delay = 700);
    
    IResultOutScheduleFromDate GetSchedule(DateOnly date, ScheduleSearchType type, string id);
    
    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnly date, ScheduleSearchType type, string id);
    
    IList<IResultOutScheduleFromDate> GetSchedule(DateOnly startDate, DateOnly endDate, ScheduleSearchType type, string id, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, ScheduleSearchType type, string id, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnly date, ScheduleSearchType type, int delay = 700);
}