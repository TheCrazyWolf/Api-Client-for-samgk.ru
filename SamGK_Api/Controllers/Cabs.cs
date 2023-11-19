using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Models.Cabs;

namespace SamGK_Api.Controllers;

public class Cabs : _BaseController, ICab
{
    private IEnumerable<ICabsResult>? _cachedCabs;
    
    public IEnumerable<ICabsResult>? Get(bool forceLoad = false)
    {
        if (_cachedCabs != null && !forceLoad)
            return _cachedCabs;
        
        var options = new RestRequest("https://asu.samgk.ru/api/teachers", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");
        
        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedCabs = JsonConvert.DeserializeObject<IEnumerable<CabResult>>(result.Content);
        return _cachedCabs;
    }

    public async Task<IEnumerable<ICabsResult>?> GetAsync(bool forceLoad = false)
    {
        if (_cachedCabs != null && !forceLoad)
            return _cachedCabs;
        
        var options = new RestRequest("https://asu.samgk.ru/api/teachers", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedCabs = JsonConvert.DeserializeObject<IEnumerable<CabResult>>(result.Content);
        return _cachedCabs;
    }
}