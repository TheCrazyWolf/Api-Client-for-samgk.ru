using System.Collections.ObjectModel;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Common;

public class CommonCache 
{
    protected static IList<IResultOutCab> CachesCabs = new Collection<IResultOutCab>();
    protected static IList<IResultOutGroup> CachesGroups = new Collection<IResultOutGroup>();
    protected static IList<IResultOutIdentity> CachedIdentities = new Collection<IResultOutIdentity>();
}