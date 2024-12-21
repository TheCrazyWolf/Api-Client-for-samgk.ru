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
    protected int DefaultLifeTimeInMinutesShort = 10; // 10 минут

    protected IList<LifeTimeMemory<IResultOutScheduleFromDate>> ScheduleCache = [];
    protected IList<LifeTimeMemory<IResultOutCab>> CabsCache = [];
    protected IList<LifeTimeMemory<IResultOutGroup>> GroupsCache = [];
    protected IList<LifeTimeMemory<IResultOutIdentity>> IdentityCache = [];
    protected bool ForceUpdateCache => IsCacheOutdated(CabsCache) || IsCacheOutdated(IdentityCache) || IsCacheOutdated(GroupsCache);
    protected void ClearCacheIfOutDate()
    {
        ClearCache(ScheduleCache);
        ClearCache(CabsCache);
        ClearCache(GroupsCache);
        ClearCache(IdentityCache);
    }
    protected void SaveToCache(IResultOutScheduleFromDate schedule, int lifeTimeInMinutes) => SaveToCache(schedule, lifeTimeInMinutes, ScheduleCache);
    protected void SaveToCache(IResultOutIdentity identity, int lifeTimeInMinutes) => SaveToCache(identity, lifeTimeInMinutes, IdentityCache);
    protected void SaveToCache(IResultOutGroup group, int lifeTimeInMinutes) => SaveToCache(group, lifeTimeInMinutes, GroupsCache);
    protected void SaveToCache(IResultOutCab cab, int lifeTimeInMinutes) => SaveToCache(cab, lifeTimeInMinutes, CabsCache);

    public IResultOutScheduleFromDate? ExtractFromScheduleCache(DateOnly date, ScheduleSearchType type, string? id) => ExtractFromCache(r => r.Date == date && r.SearchType == type && r.IdValue == id, ScheduleCache);
    public IResultOutCab? ExtractFromCabCache(string? id) => ExtractFromCache(r => r.Adress == id, CabsCache);
    public IResultOutGroup? ExtractFromGroupCache(long? id) => ExtractFromCache(r => r.Id == id, GroupsCache);
    public IResultOutIdentity? ExtractFromIdentityCache(long? id) => ExtractFromCache(r => r.Id == id, IdentityCache);

    T? ExtractFromCache<T>(Func<T, bool> predicate, IList<LifeTimeMemory<T>> cache) where T : class
    {
        ClearCacheIfOutDate();
        return cache.FirstOrDefault(x => predicate(x.Object))?.Object;
    }

    void SaveToCache<T>(T item, int lifeTimeInMinutes, IList<LifeTimeMemory<T>> cache)
    {
        var cacheItem = new LifeTimeMemory<T>()
        {
            Object = item,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        cache.Add(cacheItem);
    }

    void ClearCache<T>(IList<LifeTimeMemory<T>> cache) where T : class
    {
        foreach (var item in cache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
        {
            cache.Remove(item);
        }
    }

    bool IsCacheOutdated<T>(IEnumerable<LifeTimeMemory<T>> cache) => !cache.Any() || cache.Any(x => x.DateTimeCanBeDeleted <= DateTime.Now);
}