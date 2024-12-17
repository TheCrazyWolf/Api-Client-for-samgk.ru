using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

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
}