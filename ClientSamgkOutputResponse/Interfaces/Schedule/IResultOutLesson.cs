using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutLesson
{
    public IList<IResultOutIdentity> Identity { get; set; }
    public IResultOutGroup EducationGroup { get; set; }
    public IResultOutSubjectItem SubjectDetails { get; set; }
    public IList<IResultOutCab> Cabs { get; set; }
    public long NumPair { get; set; }
    public long NumLesson { get; set; }
    public TimeOnlyLegacy DurationStart { get; set; } 
    public TimeOnlyLegacy DurationEnd { get; set; } 
}