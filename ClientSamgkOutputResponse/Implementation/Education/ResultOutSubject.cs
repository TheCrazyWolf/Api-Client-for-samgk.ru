using ClientSamgkOutputResponse.Interfaces.Education;

namespace ClientSamgkOutputResponse.Implementation.Education;

public class ResultOutSubject : IResultOutSubjectItem
{
    public long Id { get; set; } 
    public string SubjectName { get; set; } = string.Empty;
}