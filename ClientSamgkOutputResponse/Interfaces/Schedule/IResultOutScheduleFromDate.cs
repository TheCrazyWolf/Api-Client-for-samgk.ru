namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutScheduleFromDate
{
    public DateOnly Date { get; set; }
    public IList<IResultOutLesson> Lessons { get; set; }
}