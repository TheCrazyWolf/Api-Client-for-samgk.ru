using ClientSamgk.Common;
using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Services;

namespace SamGK_Api.Controllers;

public class CabsController : CommonSamgkController, ICabController
{
    private IList<ICab>? _cachedCabs;
    
    public IList<ICab> GetCabs(bool forceLoad = false)
    {
        return GetCabsAsync(forceLoad: forceLoad).GetAwaiter().GetResult();
    }

    public async Task<IList<ICab>> GetCabsAsync(bool forceLoad = false)
    {
        if (_cachedCabs != null && !forceLoad)
            return _cachedCabs ?? new List<ICab>();
        
        var options = new RestRequest("https://asu.samgk.ru/api/cabs");
        options.AddHeaders(GetHeaders());
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return _cachedCabs ?? new List<ICab>();

        _cachedCabs = CabParser.Parse(JsonConvert.DeserializeObject<Dictionary<string,string>>(result.Content));
        return _cachedCabs ?? new List<ICab>();
    }

    public ICab? GetCab(string cabName)
    {
        _cachedCabs ??= GetCabs();
        return _cachedCabs?.FirstOrDefault(cab => cab.Name.ToUpper() == cabName.ToUpper());
    }
}