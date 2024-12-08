using ClientSamgk.Models;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Common;

public class CommonCache 
{
    protected IList<IResultOutCab> CachesCabs = new List<IResultOutCab>();
    protected IList<IResultOutGroup> CachesGroups = new List<IResultOutGroup>();
    protected IList<IResultOutIdentity> CachedIdentities = new List<IResultOutIdentity>();
    protected IList<LifeTimeMemory<IResultOutScheduleFromDate>> ScheduleCache = new List<LifeTimeMemory<IResultOutScheduleFromDate>>();

    public IResultOutScheduleFromDate? ExtractFromCache(DateOnly date, ScheduleSearchType type, string id)
    {
        return ScheduleCache.FirstOrDefault(x => x.Object.Date == date && x.Object.SearchType == type && x.Object.IdValue == id)?.Object;
    }

    protected void SaveToCache(IResultOutScheduleFromDate schedule, int lifeTimeInMinutes)
    {
        var item = new LifeTimeMemory<IResultOutScheduleFromDate>()
        {
            Object = schedule,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        ScheduleCache.Add(item);
    }

    protected void ClearCacheIfOutDate()
    {
        foreach (var item in ScheduleCache.Where(x => x.DateTimeCanBeDeleted <= DateTime.Now).ToList()) ScheduleCache.Remove(item);
    }
    
}