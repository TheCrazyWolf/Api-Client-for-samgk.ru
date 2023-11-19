namespace SamGK_Api.Interfaces.Shedule;

public interface ISheduleDate
{
    public string Date { get; set; }
    public IEnumerable<ILesson> Lessons { get; set; }
}