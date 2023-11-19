using SamGK_Api.Controllers;
using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk : IDisposable
{
    public IShedule Shedule { get; protected set; }
    public IAccount Account { get; protected set; }
    public IGroup Groups { get; protected set; }

    public ClientSamgk()
    {
        Groups = new Groups();
        Account = new Account();
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}