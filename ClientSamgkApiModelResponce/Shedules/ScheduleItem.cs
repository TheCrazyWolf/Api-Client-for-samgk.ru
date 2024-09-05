using ClientSamgkApiModelResponse.Education;

namespace ClientSamgkApiModelResponse.Shedules;

public class ScheduleItem
{
    public int Id { get; set; }
    public int Group { get; set; }
    public string GroupName { get; set; }
    public int Discipline { get; set; }
    public DisciplineInfo DisciplineInfo { get; set; }
    public string DisciplineName { get; set; }
    public List<int> Teacher { get; set; }
    public List<string> TeacherName { get; set; }
    public List<string> Cab { get; set; }
    public int Pair { get; set; }
    public int Number { get; set; }
    public List<object> FactsTeacher { get; set; }
    public int Invisible { get; set; }
    public int Zachet { get; set; }
}