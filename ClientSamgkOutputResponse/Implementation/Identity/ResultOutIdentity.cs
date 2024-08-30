using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Identity;

public class ResultOutIdentity : IResultOutIdentity
{
    public string Id { get; set; }
    public string Name { get; set; }
}