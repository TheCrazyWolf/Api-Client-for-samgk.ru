using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Groups;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutLesson : IResultOutLesson
{
    public IList<IResultOutIdentity> Identity { get; set; } = new List<IResultOutIdentity>();
    public IResultOutGroup EducationGroup { get; set; } = new ResultOutGroup();
    public IResultOutSubjectItem SubjectDetails { get; set; } = new ResultOutCabSubject();
    public IList<IResultOutCab> Cabs { get; set; } = new List<IResultOutCab>();
    public int NumPair { get; set; }
    public int NumLesson { get; set; }
}