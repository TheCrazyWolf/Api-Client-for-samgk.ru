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
    public IResultOutSubjectItem SubjectDetails { get; set; } = new ResultOutSubject();
    public IList<IResultOutCab> Cabs { get; set; } = new List<IResultOutCab>();
    public long NumPair { get; set; }
    public long NumLesson { get; set; }
    public TimeOnly DurationStart { get; set; } = new TimeOnly(0, 0, 0);
    public TimeOnly DurationEnd { get; set; } = new TimeOnly(0, 0, 0);
}