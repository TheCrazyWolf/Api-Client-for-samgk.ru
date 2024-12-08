using ClientSamgk.Models;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Common;

public class CommonCache 
{
    
    protected IList<LifeTimeMemory<IResultOutScheduleFromDate>> ScheduleCache = new List<LifeTimeMemory<IResultOutScheduleFromDate>>();
    protected IList<LifeTimeMemory<IResultOutCab>> CabsCache = new List<LifeTimeMemory<IResultOutCab>>();
    protected IList<LifeTimeMemory<IResultOutGroup>> GroupsCache = new List<LifeTimeMemory<IResultOutGroup>>();
    protected IList<LifeTimeMemory<IResultOutIdentity>> IdentityCache = new List<LifeTimeMemory<IResultOutIdentity>>();
    
    public IResultOutScheduleFromDate? ExtractFromCache(DateOnly date, ScheduleSearchType type, string? id)
    {
        ClearCacheIfOutDate();
        return ScheduleCache.FirstOrDefault(x => x.Object.Date == date && x.Object.SearchType == type && x.Object.IdValue == id)?.Object;
    }
    
    public IResultOutCab? ExtractCabFromCache(string? id)
    {
        ClearCacheIfOutDate();
        return CabsCache.FirstOrDefault(x => x.Object.Adress == id)?.Object;
    }
    
    public IResultOutGroup? ExtractGroupFromCache(long? id)
    {
        ClearCacheIfOutDate();
        return GroupsCache.FirstOrDefault(x => x.Object.Id == id)?.Object;
    }
    
    public IResultOutIdentity? ExtractIdentityFromCache(long? id)
    {
        ClearCacheIfOutDate();
        return IdentityCache.FirstOrDefault(x => x.Object.Id == id)?.Object;
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
    
    protected void SaveToCache(IResultOutIdentity identity, int lifeTimeInMinutes)
    {
        var item = new LifeTimeMemory<IResultOutIdentity>()
        {
            Object = identity,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        IdentityCache.Add(item);
    }
    
    protected void SaveToCache(IResultOutGroup schedule, int lifeTimeInMinutes)
    {
        var item = new LifeTimeMemory<IResultOutGroup>()
        {
            Object = schedule,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        GroupsCache.Add(item);
    }
    
    protected void SaveToCache(IResultOutCab schedule, int lifeTimeInMinutes)
    {
        var item = new LifeTimeMemory<IResultOutCab>()
        {
            Object = schedule,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        CabsCache.Add(item);
    }

    protected void ClearCacheIfOutDate()
    {
        foreach (var item in ScheduleCache.Where(x => x.DateTimeCanBeDeleted <= DateTime.Now).ToList()) ScheduleCache.Remove(item);
        foreach (var item in CabsCache.Where(x => x.DateTimeCanBeDeleted <= DateTime.Now).ToList()) CabsCache.Remove(item);
        foreach (var item in GroupsCache.Where(x => x.DateTimeCanBeDeleted <= DateTime.Now).ToList()) GroupsCache.Remove(item);
        foreach (var item in IdentityCache.Where(x => x.DateTimeCanBeDeleted <= DateTime.Now).ToList()) IdentityCache.Remove(item);
    }

    protected bool IsRequiredToForceUpdateCache()
    {
        if (CabsCache.Any(x => x.DateTimeCanBeDeleted <= DateTime.Now) || !CabsCache.Any())
            return true;
        if (IdentityCache.Any(x => x.DateTimeCanBeDeleted <= DateTime.Now) || !IdentityCache.Any())
            return true;
        if (GroupsCache.Any(x => x.DateTimeCanBeDeleted <= DateTime.Now) || !GroupsCache.Any())
            return true;

        return false;
    }
}