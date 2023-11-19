using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Models.Schedule;

public class ScheduleDate : IScheduleDate
{
    public string Date { get; set; }
    public IEnumerable<ILesson> Lessons { get; set; }
}