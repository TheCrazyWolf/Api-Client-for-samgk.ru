using RestSharp;

namespace SamGK_Api.Controllers;

public class _BaseController
{
    protected RestClient _client;

    public _BaseController()
    {
        _client = new();
    }

    /// <summary>
    /// Лекарство от жадности
    /// </summary>
    /// <returns></returns>
    public ICollection<KeyValuePair<string,string>> GetHeaders()
    {
        var dickPick = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("origin", "https://samgk.ru"),
            new KeyValuePair<string, string>("referer", "https://samgk.ru"),
        };
        return dickPick;
    }
}