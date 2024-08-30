using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutLesson
{
    public IResultOutIdentity Identity { get; set; }
    public IResultOutGroup EducationGroup { get; set; }
    public IResultOutSubjectItem SubjectDetails { get; set; }
    public int NumPair { get; set; }
    public int NumLesson { get; set; }
}