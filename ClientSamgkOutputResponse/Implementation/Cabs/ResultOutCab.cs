using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgkOutputResponse.Implementation.Cabs;

public class ResultOutCab  : IResultOutCab
{
    public string Adress { get; set; } = string.Empty;
    public int Campus { get; set; }
    public string Auditory { get; set; } = string.Empty;
}