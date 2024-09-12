using ClientSamgk.Controllers;
using ClientSamgk.Interfaces.Client;

namespace ClientSamgk;

public class ClientSamgkApi
{
    public ISсheduleController Sсhedule { get; protected set; } = new ScheduleController();
    /*public IAccountController Accounts { get; protected set; } = new AccountController();*/
    public IGroupController Groups { get; protected set; } = new GroupsController();
    public ICabController Cabs { get; protected set; } = new CabsController();
}