using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Controllers;

public class CabsController : CommonSamgkController, ICabController
{
    public IList<IResultOutCab> GetCabs() => GetCabsAsync().GetAwaiter().GetResult();

    public async Task<IList<IResultOutCab>> GetCabsAsync()
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return CabsCache.Select(r => r.Object).OrderBy(r => r.Adress).ToList();
    }

    public IResultOutCab? GetCab(string cabName) => GetCabAsync(cabName).GetAwaiter().GetResult();

    public async Task<IResultOutCab?> GetCabAsync(string cabName)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return CabsCache.Select(r => r.Object)
            .FirstOrDefault(x => x.Adress.Equals(cabName, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<IList<IResultOutCab>> GetCabsAsync(string campusNumber)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return CabsCache.Select(r => r.Object).Where(x => x.Campus == campusNumber).ToList();
    }

    public IList<IResultOutCab> GetCabs(string campusNumber) => GetCabsAsync(campusNumber).GetAwaiter().GetResult();

    public IList<string> GetCampuses() => GetCampusesAsync().GetAwaiter().GetResult();

    public async Task<IList<string>> GetCampusesAsync()
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return CabsCache.Select(r => r.Object).Select(r => r.Campus).Distinct().ToList();
    }

    public async Task<IList<IResultOutCab>> GetCabsFromCampusAsync(string campusName)
    {
        await UpdateIfCacheIsOutdated().ConfigureAwait(false);
        return CabsCache.Select(r => r.Object)
            .Where(r => string.Equals(r.Campus, campusName, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public IList<IResultOutCab> GetCabsFromCampus(string campusName) =>
        GetCabsFromCampusAsync(campusName).GetAwaiter().GetResult();
}