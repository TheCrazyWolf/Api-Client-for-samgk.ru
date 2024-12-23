using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Controllers;

public class AccountController : CommonSamgkController, IIdentityController
{
    public IList<IResultOutIdentity> GetTeachers() => GetTeachersAsync().GetAwaiter().GetResult();

    public async Task<IList<IResultOutIdentity>> GetTeachersAsync()
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return IdentityCache.Select(r => r.Object).OrderBy(r => r.Name).ToList();
    }

    public IResultOutIdentity? GetTeacher(string teacherName) => GetTeacherAsync(teacherName).GetAwaiter().GetResult();

    public IResultOutIdentity? GetTeacher(long id) => GetTeacherAsync(id).GetAwaiter().GetResult();

    public async Task<IResultOutIdentity?> GetTeacherAsync(long id)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return ExtractFromIdentityCache(id);
    }

    public async Task<IResultOutIdentity?> GetTeacherAsync(string teacherName)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);

        return IdentityCache.Select(r => r.Object).FirstOrDefault(x =>
            string.Equals(x.Name, teacherName, StringComparison.CurrentCultureIgnoreCase));
    }
}