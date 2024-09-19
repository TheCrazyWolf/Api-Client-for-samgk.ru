using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Controllers;

public class CabsController : CommonSamgkController, ICabController
{
    public IList<IResultOutCab> GetCabs()
    {
        return GetCabsAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutCab>> GetCabsAsync()
    {
        await ConfiguringCache();
        return CachesCabs.OrderBy(x=> x.Adress).ToList();
    }

    public IResultOutCab? GetCab(string cabName)
    {
        return GetCabAsync(cabName).GetAwaiter().GetResult();
    }

    public async Task<IResultOutCab?> GetCabAsync(string cabName)
    {
        await ConfiguringCache();
        return CachesCabs.FirstOrDefault(x=> x.Adress.Equals(cabName, 
            StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<IList<IResultOutCab>> GetCabsAsync(int campusNumber)
    {
        await ConfiguringCache();
        return CachesCabs.Where(x=> x.Campus == campusNumber).ToList();
    }

    public IList<IResultOutCab> GetCabs(int campusNumber)
    {
        return GetCabsAsync(campusNumber).GetAwaiter().GetResult();
    }
}