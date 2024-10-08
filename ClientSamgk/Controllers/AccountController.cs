using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Controllers;

public class AccountController : CommonSamgkController, IIdentityController
{
    public IList<IResultOutIdentity> GetTeachers()
    {
        return GetTeachersAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutIdentity>> GetTeachersAsync()
    {
        await ConfiguringCache();
        return CachedIdentities.OrderBy(x=> x.Name).ToList();
    }

    public IResultOutIdentity? GetTeacher(string teacherName)
    {
        return GetTeacherAsync(teacherName).GetAwaiter().GetResult();
    }

    public IResultOutIdentity? GetTeacher(long id)
    {
        return GetTeacherAsync(id).GetAwaiter().GetResult();
    }

    public async Task<IResultOutIdentity?> GetTeacherAsync(long id)
    {
        await ConfiguringCache();
        return CachedIdentities.FirstOrDefault(x=> x.Id == id);
    }

    public async Task<IResultOutIdentity?> GetTeacherAsync(string teacherName)
    {
        await ConfiguringCache();
        return CachedIdentities.FirstOrDefault(x=> string.Equals(x.Name, teacherName, 
            StringComparison.CurrentCultureIgnoreCase));
    }
}