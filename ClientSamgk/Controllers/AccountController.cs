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
        await UpdateIfCacheIsOutdated();
        return IdentityCache.Select(x=>x.Object).OrderBy(x=> x.Name).ToList();
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
        await UpdateIfCacheIsOutdated();
        return ExtractIdentityFromCache(id);
    }

    public async Task<IResultOutIdentity?> GetTeacherAsync(string teacherName)
    {
        await UpdateIfCacheIsOutdated();
        return IdentityCache.Select(x=> x.Object)
            .FirstOrDefault(x=> string.Equals(x.Name, teacherName, StringComparison.CurrentCultureIgnoreCase));
    }
}