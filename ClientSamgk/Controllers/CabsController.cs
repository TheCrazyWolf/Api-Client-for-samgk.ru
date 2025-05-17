using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Cabs;

namespace ClientSamgk.Controllers;

public class CabsController(CacheManager<IResultOutCab> cabsCacheManager) : ICabController
{
    public IList<IResultOutCab> GetCabs()
    {
        return GetCabsAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutCab>> GetCabsAsync()
    {
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return cabsCacheManager.Data.Select(x => x.Object).OrderBy(x => x.Adress).ToList();
    }

    public IResultOutCab? GetCab(string cabName)
    {
        return GetCabAsync(cabName).GetAwaiter().GetResult();
    }

    public async Task<IResultOutCab?> GetCabAsync(string cabName)
    {
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return cabsCacheManager.Data.Select(x => x.Object)
            .FirstOrDefault(x => x.Adress.Equals(cabName, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<IList<IResultOutCab>> GetCabsAsync(string campusNumber)
    {
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return cabsCacheManager.Data.Select(x => x.Object).Where(x => x.Campus == campusNumber).ToList();
    }

    public IList<IResultOutCab> GetCabs(string campusNumber)
    {
        return GetCabsAsync(campusNumber).GetAwaiter().GetResult();
    }

    public IList<string> GetCampuses()
    {
        return GetCampusesAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<string>> GetCampusesAsync()
    {
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return cabsCacheManager.Data.Select(x => x.Object).Select(x => x.Campus).Distinct().ToList();
    }

    public async Task<IList<IResultOutCab>> GetCabsFromCampusAsync(string campusName)
    {
        await cabsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return cabsCacheManager.Data.Select(x => x.Object).Where(x => string.Equals(x.Campus, campusName,
            StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public IList<IResultOutCab> GetCabsFromCampus(string campusName)
    {
        return GetCabsFromCampusAsync(campusName).GetAwaiter().GetResult();
    }
}