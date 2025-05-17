using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Controllers;

public class MemoryCacheController(
    CacheManager<IResultOutIdentity> teachersCacheManager,
    CacheManager<IResultOutGroup> groupsCacheManager,
    CacheManager<IResultOutCab> cabsCacheManager,
    ICache<IResultOutScheduleFromDate> schedulesCache,
    ICacheOptions cacheOptions
) : IMemoryCacheController
{
    public async Task ClearIfOutDateAsync()
    {
        await teachersCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        await groupsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);

        teachersCacheManager.Cache.CleanupCache();
        groupsCacheManager.Cache.CleanupCache();
        cabsCacheManager.Cache.CleanupCache();
    }

    public void ClearIfOutDate()
    {
        ClearIfOutDateAsync().GetAwaiter().GetResult();
    }

    public void Clear()
    {
        teachersCacheManager.Cache.DropCache();
        groupsCacheManager.Cache.DropCache();
        cabsCacheManager.Cache.DropCache();
        schedulesCache.DropCache();
    }

    public void SetLifeTime(ICacheOptions options)
    {
        cacheOptions.LifeTimeObjectsForCommon = options.LifeTimeObjectsForCommon;
        cacheOptions.LifeTimeObjectsForLong = options.LifeTimeObjectsForLong;
        cacheOptions.LifeTimeObjectsForShort = options.LifeTimeObjectsForShort;
    }
}