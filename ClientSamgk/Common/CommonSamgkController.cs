using ClientSamgk.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace ClientSamgk.Common;

public class CommonSamgkController : CommonCache
{
    protected readonly RestClient Client;
    
    protected CommonSamgkController()
    {
        Client = new RestClient();
    }

    private async Task<T> SendRequest<T>(string url)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content == null)
            throw new Exception("");

        return JsonConvert.DeserializeObject<T>(result.Content);
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