using ClientSamgkOutputResponse.Interfaces.Schedule;
using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutScheduleFromDate : IResultOutScheduleFromDate
{
    public DateOnlyLegacy Date { get; set; } = new DateOnlyLegacy();
    public IList<IResultOutLesson> Lessons { get; set; } = new List<IResultOutLesson>();
}