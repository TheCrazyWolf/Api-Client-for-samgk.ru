using System.Collections.ObjectModel;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Common;

public class CommonCache 
{
    protected IList<IResultOutCab> CachesCabs = new Collection<IResultOutCab>();
    protected IList<IResultOutGroup> CachesGroups = new Collection<IResultOutGroup>();
    protected IList<IResultOutIdentity> CachedIdentities = new Collection<IResultOutIdentity>();
}