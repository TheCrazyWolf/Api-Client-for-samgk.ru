using ClientSamgkOutputResponse.Interfaces.Education;

namespace ClientSamgkOutputResponse.Implementation.Education;

public class ResultOutCabSubject : IResultOutSubjectItem
{
    public int Id { get; set; } 
    public string SubjectName { get; set; } = string.Empty;
}