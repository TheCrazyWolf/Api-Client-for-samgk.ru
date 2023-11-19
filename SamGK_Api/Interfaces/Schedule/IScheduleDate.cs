namespace SamGK_Api.Interfaces.Schedule;

public interface IScheduleDate
{
    public string Date { get; set; }
    public IEnumerable<ILesson> Lessons { get; set; }
}