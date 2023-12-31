using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Models.Schedule;

public class Lesson : ILesson
{
    public string? Num { get; set; }
    public string? Title { get; set; }
    public string? Teachername { get; set; }
    public string? NameGroup { get; set; }
    public string? Cab { get; set; }
    public string? Resource { get; set; }
}