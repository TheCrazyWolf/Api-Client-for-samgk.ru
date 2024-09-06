using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Controllers;

public class CabsController : CommonSamgkController, ICabController
{
    public IList<IResultOutCab> GetCabs()
    {
        return CachesCabs;
    }

    public IResultOutCab? GetCab(string cabName)
    {
        return CachesCabs.FirstOrDefault(x=> x.Adress.Equals(cabName, 
            StringComparison.CurrentCultureIgnoreCase));
    }
}