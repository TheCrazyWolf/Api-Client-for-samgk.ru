using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;

namespace ClientSamgk.Controllers;

public class MemoryCacheController : CommonSamgkController, IMemoryCacheController
{
    public async Task ClearIfOutDateAsync()
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        ClearCacheIfOutDate();
    }

    public void ClearIfOutDate() => ClearIfOutDateAsync().GetAwaiter().GetResult();

    public void Clear()
    {
        CabsCache = [];
        IdentityCache = [];
        GroupsCache = [];  
        ScheduleCache = [];
    }
}