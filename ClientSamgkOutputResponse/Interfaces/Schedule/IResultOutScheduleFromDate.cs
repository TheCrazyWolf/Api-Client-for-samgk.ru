namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutScheduleFromDate
{
    /// <summary>
    /// Дата
    /// </summary>
    public DateOnly Date { get; set; }
    /// <summary>
    /// Коллекция занятия
    /// </summary>
    public IList<IResultOutLesson> Lessons { get; set; }
}