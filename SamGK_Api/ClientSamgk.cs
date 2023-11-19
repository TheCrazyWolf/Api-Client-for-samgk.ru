using SamGK_Api.Controllers;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk : IDisposable
{
    public ISсhedule Sсhedule { get; protected set; }
    public IAccount Account { get; protected set; }
    public IGroup Groups { get; protected set; }
    public ICab Cabs { get; protected set; }

    public ClientSamgk()
    {
        Groups = new Groups();
        Account = new Account();
        Cabs = new Cabs();
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}