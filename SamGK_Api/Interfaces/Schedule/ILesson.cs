namespace SamGK_Api.Interfaces.Schedule;

public interface ILesson
{
    public string? num { get; set; }
    public string? title { get; set; }
    public string? teachername { get; set; }
    public string? nameGroup { get; set; }
    public string? cab { get; set; }
    public string? resource { get; set; }
}