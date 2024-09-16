using ClientSamgk.Controllers;
using ClientSamgk.Interfaces.Client;

namespace ClientSamgk;

public class ClientSamgkApi : IClientSamgkApi
{
    public ISсheduleController Schedule { get; protected set; } = new ScheduleController();
    public IIdentityController Accounts { get; protected set; } = new AccountController();
    public IGroupController Groups { get; protected set; } = new GroupsController();
    public ICabController Cabs { get; protected set; } = new CabsController();
}