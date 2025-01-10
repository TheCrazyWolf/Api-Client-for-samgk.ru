using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Controllers;

public class MemoryCacheController : CommonSamgkController, IMemoryCacheController
{
    public async Task ClearIfOutDateAsync()
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        ClearCacheIfOutDate();
    }

    public void ClearIfOutDate()
    {
        ClearIfOutDateAsync().GetAwaiter().GetResult();
    }

    public void Clear()
    {
        CabsCache = new List<LifeTimeMemory<IResultOutCab>>();
        IdentityCache = new List<LifeTimeMemory<IResultOutIdentity>>();
        GroupsCache = new List<LifeTimeMemory<IResultOutGroup>>();
        ScheduleCache = new List<LifeTimeMemory<IResultOutScheduleFromDate>>();
    }

    public void SetLifeTime(ICacheOptions options)
    {
        DefaultLifeTimeInMinutesForCommon = options.LifeTimeCommonObjects;
        DefaultLifeTimeInMinutesLong = options.LifeTimeObjectsForLong;
        DefaultLifeTimeInMinutesShort = options.LifeTimeObjectsForShort;
    }
}