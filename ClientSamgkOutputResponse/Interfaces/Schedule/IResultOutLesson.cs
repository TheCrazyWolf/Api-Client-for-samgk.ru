using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutLesson
{
    public IList<IResultOutIdentity> Identity { get; set; }
    public IResultOutGroup EducationGroup { get; set; }
    public IResultOutSubjectItem SubjectDetails { get; set; }
    public IList<IResultOutCab> Cabs { get; set; }
    public long NumPair { get; set; }
    public long NumLesson { get; set; }
    public TimeOnly DurationStart { get; set; } 
    public TimeOnly DurationEnd { get; set; } 
}