using SamGK_Api.Controllers;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk : IDisposable
{
    public ISсheduleController SсheduleController { get; protected set; }
    public IAccountController AccountController { get; protected set; }
    public IGroupController GroupsController { get; protected set; }
    public ICabController CabsController { get; protected set; }

    public ClientSamgk()
    {
        GroupsController = new GroupsController();
        AccountController = new AccountController();
        CabsController = new CabsController();
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}