using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutScheduleFromDate : IResultOutScheduleFromDate
{
    public DateOnly Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; } = new List<IResultOutLesson>();
    public ScheduleSearchType SearchType { get; set; }
    public string IdValue { get; set; } = string.Empty;
    public ScheduleCallType CallType { get; set; }
}