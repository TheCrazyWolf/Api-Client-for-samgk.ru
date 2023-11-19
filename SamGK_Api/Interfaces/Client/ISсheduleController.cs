using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Interfaces.Client;

public interface ISсheduleController
{
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IEmployee entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IEmployee entity, int delay = 700);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IGroup entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, ICab entity);
    IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700);

}