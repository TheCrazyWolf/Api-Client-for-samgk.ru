using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgkOutputResponse.Implementation.Cabs;

public class ResultOutCab : IResultOutCab
{
    public string Adress { get; set; } = string.Empty;
    public string Campus => GetPartOfAddress(0);
    public string Auditory => GetPartOfAddress(1);

    string GetPartOfAddress(int index)
    {
        var parts = Adress.Split('/');
        return parts.Length == 2 && index < parts.Length ? parts[index] : Adress;
    }
}