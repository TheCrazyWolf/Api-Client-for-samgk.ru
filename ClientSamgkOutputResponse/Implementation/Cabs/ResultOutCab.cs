using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgkOutputResponse.Implementation.Cabs;

public class ResultOutCab  : IResultOutCab
{
    public string Adress { get; set; } = string.Empty;
    public string Campus => GetCampus(Adress);
    public string Auditory => GetAuditory(Adress);

    private string GetCampus(string fullAdress)
    {
        var array = fullAdress.Split('/');
        return array.Length != 2 ? fullAdress : array[0];
    }

    private string GetAuditory(string fullAdress)
    {
        var array = fullAdress.Split('/');
        return array.Length != 2 ? fullAdress : array[1];
    }
}