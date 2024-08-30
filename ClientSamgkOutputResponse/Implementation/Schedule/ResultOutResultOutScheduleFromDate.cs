using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutScheduleFromDate : IResultOutScheduleFromDate
{
    public DateOnly Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; }
}