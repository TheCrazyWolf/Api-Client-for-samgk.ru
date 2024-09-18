using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Groups;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;
using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgkOutputResponse.Implementation.Schedule;

public class ResultOutResultOutLesson : IResultOutLesson
{
    public IList<IResultOutIdentity> Identity { get; set; } = new List<IResultOutIdentity>();
    public IResultOutGroup EducationGroup { get; set; } = new ResultOutGroup();
    public IResultOutSubjectItem SubjectDetails { get; set; } = new ResultOutSubject();
    public IList<IResultOutCab> Cabs { get; set; } = new List<IResultOutCab>();
    public long NumPair { get; set; }
    public long NumLesson { get; set; }
    public TimeOnlyLegacy DurationStart { get; set; } = new TimeOnlyLegacy(0, 0);
    public TimeOnlyLegacy DurationEnd { get; set; } = new TimeOnlyLegacy(0, 0);
}