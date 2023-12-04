using SamGK_Api.Controllers;
using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk
{
    public ISсheduleController Sсhedule { get; protected set; } = new ScheduleController();
    public IAccountController Accounts { get; protected set; } = new AccountController();
    public IGroupController Groups { get; protected set; } = new GroupsController();
    public ICabController Cabs { get; protected set; } = new CabsController();
}