using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Groups;

public class ResultOutGroup : IResultOutGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IResultOutIdentity? Currator { get; set; }
}