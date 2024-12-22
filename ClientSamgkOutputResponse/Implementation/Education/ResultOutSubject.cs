using ClientSamgkOutputResponse.Interfaces.Education;

namespace ClientSamgkOutputResponse.Implementation.Education;

public class ResultOutSubject : IResultOutSubjectItem
{
    public ResultOutSubject(long id, string index, string subjectName, bool isAttestation)
    {
        Id = id;
        Index = index;
        SubjectName = subjectName;
        IsAttestation = isAttestation;
    }
    public ResultOutSubject(long id, string index, string subjectName)
    {
        Id = id;
        Index = index;
        SubjectName = subjectName;
    }
    public ResultOutSubject() { }

    public long Id { get; set; }
    public string Index { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public string FullSubjectName => $"{Index} {SubjectName}";
    public bool IsAttestation { get; set; } 
}