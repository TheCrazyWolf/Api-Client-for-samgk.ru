using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Models;

public class ScheduleCache
{
    public DateTime DateTimeAdded { get; set; }
    public IResultOutScheduleFromDate Schedule { get; set; } = default!;
}