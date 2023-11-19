using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Interfaces.Client;

public interface ISсheduleController
{
    IEnumerable<IScheduleDate>? Get<T>(DateOnly date, T entity);
    IEnumerable<IScheduleDate>? Get<TIEmployee>(DateOnly date, IEmployee entity);
}