using ClientSamgk.Controllers;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk;

public class ClientSamgkApi : IClientSamgkApi
{
    public ISсheduleController Schedule { get; protected set; } = new ScheduleController();
    public IIdentityController Accounts { get; protected set; } = new AccountController();
    public IGroupController Groups { get; protected set; } = new GroupsController();
    public ICabController Cabs { get; protected set; } = new CabsController();
    public IMemoryCacheController Cache { get; protected set; } = new MemoryCacheController();

    public ClientSamgkApi()
    {
        
    }

    public ClientSamgkApi(ICacheOptions cacheOptions)
    {
        Cache.SetLifeTime(cacheOptions);
    }
}