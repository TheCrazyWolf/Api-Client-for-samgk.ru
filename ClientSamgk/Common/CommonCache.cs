using ClientSamgk.Models;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Common;

public class CommonCache
{
    protected int DefaultLifeTimeInMinutesForCommon = 2880; // 2 дня
    protected int DefaultLifeTimeInMinutesLong = 43200; // 1 месяц
    protected int DefaultLifeTimeInMinutesShort = 10; // 10минут

    protected IList<LifeTimeMemory<IResultOutScheduleFromDate>> ScheduleCache =
        new List<LifeTimeMemory<IResultOutScheduleFromDate>>();

    protected IList<LifeTimeMemory<IResultOutCab>> CabsCache = new List<LifeTimeMemory<IResultOutCab>>();
    protected IList<LifeTimeMemory<IResultOutGroup>> GroupsCache = new List<LifeTimeMemory<IResultOutGroup>>();
    protected IList<LifeTimeMemory<IResultOutIdentity>> IdentityCache = new List<LifeTimeMemory<IResultOutIdentity>>();

    public IResultOutScheduleFromDate? ExtractFromCache(DateOnly date, ScheduleSearchType type, string? id)
    {
        ClearCacheIfOutDate();
        return ScheduleCache
            .FirstOrDefault(x => x.Object.Date == date && x.Object.SearchType == type && x.Object.IdValue == id)
            ?.Object;
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
        foreach (var item in ScheduleCache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
        {
            ScheduleCache.Remove(item);
        }

        foreach (var item in CabsCache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
        {
            CabsCache.Remove(item);
        }

        foreach (var item in GroupsCache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
        {
            GroupsCache.Remove(item);
        }

        foreach (var item in IdentityCache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
        {
            IdentityCache.Remove(item);
        }
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