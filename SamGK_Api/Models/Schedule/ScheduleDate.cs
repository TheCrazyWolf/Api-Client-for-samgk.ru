using SamGK_Api.Interfaces.Schedule;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SamGK_Api.Models.Schedule;

public class ScheduleDate : IScheduleDate
{
    public string Date { get; set; }

    public DateOnly DateStructure
    {
        get
        {
            var array= Date.Split(".");
            return new DateOnly(Convert.ToInt16(array[2]), Convert.ToInt16(array[1]), Convert.ToInt16(array[0]));
        }
    }
    public IEnumerable<ILesson> Lessons { get; set; } = new List<Lesson>();
}