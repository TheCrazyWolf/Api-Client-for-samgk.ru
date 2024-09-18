using ClientSamgk.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;
using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgk.Interfaces.Client;

public interface ISсheduleController
{
    IResultOutScheduleFromDate GetSchedule(DateOnlyLegacy date, IResultOutIdentity entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnlyLegacy date, IResultOutIdentity entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutIdentity entity,
        int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutIdentity entity,
        int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateOnlyLegacy date, IResultOutGroup entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnlyLegacy date, IResultOutGroup entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutGroup entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutGroup entity,
        int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateOnlyLegacy date, IResultOutCab entity);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnlyLegacy date, IResultOutCab entity);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutCab entity, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnlyLegacy startDate, DateOnlyLegacy endDate, IResultOutCab entity,
        int delay = 700);

    IResultOutScheduleFromDate GetSchedule(DateOnlyLegacy date, ScheduleSearchType type, string id);

    Task<IResultOutScheduleFromDate> GetScheduleAsync(DateOnlyLegacy date, ScheduleSearchType type, string id);

    IList<IResultOutScheduleFromDate> GetSchedule(DateOnlyLegacy startDate, DateOnlyLegacy endDate, ScheduleSearchType type, string id,
        int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(DateOnlyLegacy startDate, DateOnlyLegacy endDate, ScheduleSearchType type,
        string id, int delay = 700);

    Task<IList<IResultOutScheduleFromDate>> GetAllScheduleAsync(DateOnlyLegacy date, ScheduleSearchType type, int delay = 700);

    IList<IResultOutScheduleFromDate> GetAllSchedule(DateOnlyLegacy date, ScheduleSearchType type, int delay = 700);
}