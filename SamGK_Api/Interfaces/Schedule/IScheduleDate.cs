namespace SamGK_Api.Interfaces.Schedule;

public interface IScheduleDate
{
    public string Date { get; set; }
    public DateOnly DateStructure { get; }
    public IEnumerable<ILesson> Lessons { get; set; }
}