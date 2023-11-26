using SamGK_Api.Controllers;
using SamGK_Api.Interfaces;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk
{
    public ISсheduleController Sсhedule { get; protected set; }
    public IAccountController Accounts { get; protected set; }
    public IGroupController Groups { get; protected set; }
    public ICabController Cabs { get; protected set; }

    public ClientSamgk()
    {
        Groups = new GroupsController();
        Accounts = new AccountController();
        Cabs = new CabsController();
        Sсhedule = new ScheduleController();
    }
}