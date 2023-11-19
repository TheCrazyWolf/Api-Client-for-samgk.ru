using SamGK_Api.Interfaces.Shedule;

namespace SamGK_Api.Models.Schedule;

public class ScheduleDate : ISheduleDate
{
    public string Date { get; set; }
    public IEnumerable<ILesson> Lessons { get; set; }
}