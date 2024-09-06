using RestSharp;

namespace ClientSamgk.Utils;

public static class HeadersUtils
{
    /// <summary>
    /// Лекарство от жадности
    /// </summary>
    /// <returns></returns>
    /// 
    public static void ConfigureAntiGreedHeaders(this RestRequest request)
    {
        request.AddOrUpdateHeaders(GetHeaders());
    }

    private static ICollection<KeyValuePair<string,string>> GetHeaders()
    {
        var dickPick = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("origin", "https://samgk.ru"),
            new KeyValuePair<string, string>("referer", "https://samgk.ru"),
        };
        return dickPick;
    }
}