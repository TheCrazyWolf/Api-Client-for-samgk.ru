using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutScheduleFromDate : IResultOutScheduleFromDate
{
    public DateTime Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; } = new List<IResultOutLesson>();
}