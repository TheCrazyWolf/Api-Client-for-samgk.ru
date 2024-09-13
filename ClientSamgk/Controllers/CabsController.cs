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
}