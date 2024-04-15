using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Services;

namespace SamGK_Api.Controllers;

public class CabsController : _BaseController, ICabController
{
    private IEnumerable<ICab>? _cachedCabs;
    
    public IEnumerable<ICab>? GetCabs(bool forceLoad = false)
    {
        return GetCabsAsync(forceLoad: forceLoad).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<ICab>?> GetCabsAsync(bool forceLoad = false)
    {
        if (_cachedCabs != null && !forceLoad)
            return _cachedCabs;
        
        var options = new RestRequest("https://asu.samgk.ru/api/cabs");
        options.AddHeaders(GetHeaders());
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedCabs = CabParser.Parse(JsonConvert.DeserializeObject<Dictionary<string,string>>(result.Content));
        return _cachedCabs;
    }

    public ICab? GetCab(string cabName)
    {
        _cachedCabs ??= GetCabs();
        return _cachedCabs?.FirstOrDefault(cab => cab.Name.ToUpper() == cabName.ToUpper());
    }
}