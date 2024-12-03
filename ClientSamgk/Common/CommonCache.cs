using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Common;

public class CommonCache 
{
    protected IList<IResultOutCab> CachesCabs = new List<IResultOutCab>();
    protected IList<IResultOutGroup> CachesGroups = new List<IResultOutGroup>();
    protected IList<IResultOutIdentity> CachedIdentities = new List<IResultOutIdentity>();
}