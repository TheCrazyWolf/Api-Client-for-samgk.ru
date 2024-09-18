using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutScheduleFromDate
{
    public DateOnlyLegacy Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; }
}