using RestSharp;

namespace ClientSamgk.Controllers;

public class BaseController
{
    protected readonly RestClient Client;

    protected BaseController()
    {
        Client = new();
    }

    /// <summary>
    /// Лекарство от жадности
    /// </summary>
    /// <returns></returns>
    protected ICollection<KeyValuePair<string,string>> GetHeaders()
    {
        var dickPick = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("origin", "https://samgk.ru"),
            new KeyValuePair<string, string>("referer", "https://samgk.ru"),
        };
        return dickPick;
    }
}