using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgkOutputResponse.Implementation.Cabs;

public class ResultOutCab  : IResultOutCab
{
    public string Adress { get; set; } = string.Empty;
    public int Campus => GetCampus(Adress);
    public string Auditory => GetAuditory(Adress);

    private int GetCampus(string fullAdress)
    {
        int defaultCampus = 1;
        var array = fullAdress.Split('/');
        if (array.Length != 2) return defaultCampus;
        return int.TryParse(array[0], out int campus) ? campus : defaultCampus;
    }

    private string GetAuditory(string fullAdress)
    {
        var array = fullAdress.Split('/');
        return array.Length != 2 ? fullAdress : array[1];
    }
}