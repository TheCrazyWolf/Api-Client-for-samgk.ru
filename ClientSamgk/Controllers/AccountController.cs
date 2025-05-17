using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Identity;

namespace ClientSamgk.Controllers;

public class AccountController(CacheManager<IResultOutIdentity> identityCacheManager) : IIdentityController
{
    public IList<IResultOutIdentity> GetTeachers()
    {
        return GetTeachersAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutIdentity>> GetTeachersAsync()
    {
        await identityCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return identityCacheManager.Data.Select(x => x.Object).OrderBy(x => x.Name).ToList();
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
        await identityCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return identityCacheManager.Cache.ExtractFromCache(x => x.Id == id);
    }

    public async Task<IResultOutIdentity?> GetTeacherAsync(string teacherName)
    {
        await identityCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return identityCacheManager.Data.Select(x => x.Object)
            .FirstOrDefault(x => string.Equals(x.Name, teacherName, StringComparison.CurrentCultureIgnoreCase));
    }
}