using ClientSamgk.Cache;
using ClientSamgk.Cache.Memory;
using ClientSamgk.Controllers;
using ClientSamgk.DataFetchers;
using ClientSamgk.Interfaces;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using ClientSamgk.Models.Params.Implementations.Cache;
using ClientSamgk.Models.Params.Interfaces.Cache;
using RestSharp;

namespace ClientSamgk;

public class ClientSamgkApi : IClientSamgkApi
{
    public ISсheduleController Schedule { get; protected set; }
    public IIdentityController Accounts { get; protected set; }
    public IGroupController Groups { get; protected set; }
    public ICabController Cabs { get; protected set; }
    public IMemoryCacheController Cache { get; protected set; }

    protected ClientSamgkApi(
        ISсheduleController schedule,
        IIdentityController accounts,
        IGroupController groups,
        ICabController cabs,
        IMemoryCacheController cache)
    {
        Schedule = schedule;
        Accounts = accounts;
        Groups = groups;
        Cabs = cabs;
        Cache = cache;
    }

    public ClientSamgkApi(ICacheOptions? cacheOptions = null)
    {
        var restClient = new RestClient(new HttpClient());
        var cOptions = cacheOptions ?? new CacheOptions();

        ICache<IResultOutIdentity> teachersCache = new MemoryCache<IResultOutIdentity>();
        IDataFetcher<IResultOutIdentity> teacherDataFetcher = new TeacherDataFetcher(restClient);
        CacheManager<IResultOutIdentity> teachersCacheManager = new(teachersCache, teacherDataFetcher, cOptions);

        ICache<IResultOutGroup> groupsCache = new MemoryCache<IResultOutGroup>();
        IDataFetcher<IResultOutGroup> groupDataFetcher = new GroupDataFetcher(teachersCacheManager, restClient);
        CacheManager<IResultOutGroup> groupsCacheManager = new(groupsCache, groupDataFetcher, cOptions);

        ICache<IResultOutCab> cabsCache = new MemoryCache<IResultOutCab>();
        IDataFetcher<IResultOutCab> cabsDataFetcher = new CabsDataFetcher(restClient);
        CacheManager<IResultOutCab> cabsCacheManager = new(cabsCache, cabsDataFetcher, cOptions);

        ICache<IResultOutScheduleFromDate> schedulesCache = new MemoryCache<IResultOutScheduleFromDate>();

        Accounts = new AccountController(teachersCacheManager);
        Groups = new GroupsController(groupsCacheManager);
        Cabs = new CabsController(cabsCacheManager);

        Schedule = new ScheduleController(teachersCacheManager, groupsCacheManager, cabsCacheManager,
            schedulesCache, cOptions, restClient);
        Cache = new MemoryCacheController(teachersCacheManager, groupsCacheManager, cabsCacheManager,
            schedulesCache, cOptions);
    }
}