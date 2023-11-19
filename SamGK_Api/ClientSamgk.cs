using SamGK_Api.Interfaces.Client;

namespace SamGK_Api;

public class ClientSamgk
{
    public IShedule Shedule { get; protected set; }
    public IAccount Account { get; protected set; }
}