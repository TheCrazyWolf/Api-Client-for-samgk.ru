using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Interfaces.Client;

public interface IIdentityController
{
    IList<IResultOutIdentity> GetTeachers();
    Task<IList<IResultOutIdentity>> GetTeachersAsync();
    IResultOutIdentity? GetTeacher(string teacherName);
    Task<IResultOutIdentity?> GetTeacherAsync(string teacherName);
}