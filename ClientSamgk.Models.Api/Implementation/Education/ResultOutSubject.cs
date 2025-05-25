using ClientSamgk.Models.Api.Interfaces.Education;

namespace ClientSamgk.Models.Api.Implementation.Education;

public class ResultOutSubject : IResultOutSubjectItem
{
    public long Id { get; set; }
    public string Index { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public string FullSubjectName => $"{Index} {SubjectName}";
    public bool IsAttestation { get; set; }
    public bool IsExam { get; set; }
}