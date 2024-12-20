using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgkOutputResponse.Implementation.Cabs;

public class ResultOutCab : IResultOutCab
{
    public string Adress { get; set; } = string.Empty;
    public string Campus => getCampus(Adress);
    public string Auditory => getAuditory(Adress);

    string getCampus(string fullAdress)
    {
        var array = fullAdress.Split('/');
        return array.Length != 2 ? fullAdress : array[0];
    }

    string getAuditory(string fullAdress)
    {
        var array = fullAdress.Split('/');
        return array.Length != 2 ? fullAdress : array[1];
    }
}