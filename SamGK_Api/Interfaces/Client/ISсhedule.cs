using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Interfaces.Client;

public interface ISсhedule
{
    IEnumerable<IScheduleDate>? Get<T>(DateOnly date, T entity);
}