using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutScheduleFromDate : IResultOutScheduleFromDate
{
    public ResultOutResultOutScheduleFromDate(DateOnly date, ScheduleSearchType searchType, string idValue)
    {
        Date = date;
        SearchType = searchType;
        IdValue = idValue;
    }
    public ResultOutResultOutScheduleFromDate() { }

    public DateOnly Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; } = [];
    public ScheduleSearchType SearchType { get; set; }
    public string IdValue { get; set; } = string.Empty;
    public ScheduleCallType CallType { get; set; }
}