using ClientSamgk.Models;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Interfaces.Client;

public interface ISсheduleController
{
    public IList<IResultOutScheduleFromDate> GetSchedule(ScheduleQuery query);

    public Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(ScheduleQuery query, CancellationToken cToken = default);
}