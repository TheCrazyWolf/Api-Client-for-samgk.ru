namespace ClientSamgkModelResponceApi.Education;

public class ResponseDisciplineSchedule
{
    public int Id { get; set; }
    public int Group { get; set; }
    public int DisciplineId { get; set; }
    public ResponseDisciplineInfo ResponseDisciplineInfo { get; set; }
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