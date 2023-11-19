using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Interfaces.Client;

public interface ISсheduleController
{
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IEmployee entity);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, IEmployee entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IEmployee entity, int delay = 700);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IEmployee entity, int delay = 700);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IGroup entity);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, IGroup entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, ICab entity);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, ICab entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700);

    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, SheduleSearchType type, string id);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, SheduleSearchType type, string id);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, SheduleSearchType type, string id, int delay = 700);
    Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, SheduleSearchType type, string id, int delay = 700);
}

public enum SheduleSearchType
{
    Employee, Group, Cab
}