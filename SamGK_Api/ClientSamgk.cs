using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk : IDisposable
{
    public IShedule Shedule { get; protected set; }
    public IAccount Account { get; protected set; }
    public IGroup Group { get; protected set; }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}