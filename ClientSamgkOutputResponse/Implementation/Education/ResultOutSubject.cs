using ClientSamgkOutputResponse.Interfaces.Education;

namespace ClientSamgkOutputResponse.Implementation.Education;

public class ResultOutSubject : IResultOutSubjectItem
{
    public int Id { get; set; } 
    public string SubjectName { get; set; } = string.Empty;
}