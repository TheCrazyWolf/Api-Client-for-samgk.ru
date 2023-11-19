using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Models.Group;

namespace SamGK_Api.Controllers;

public class Groups : _BaseController, IGroup
{
    private IEnumerable<IGroupResult>? _cachedGroups;
    
    public IEnumerable<IGroupResult>? Get()
    {
        if (_cachedGroups is not null)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");
        
        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedGroups = JsonConvert.DeserializeObject<IEnumerable<GroupResult>>(result.Content);
        return _cachedGroups;
    }

    public async Task<IEnumerable<IGroupResult>?> GetAsync()
    {
        if (_cachedGroups is not null)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeader("origin", "https://samgk.ru");
        options.AddHeader("referer", "https://samgk.ru");
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedGroups = JsonConvert.DeserializeObject<IEnumerable<GroupResult>>(result.Content);
        return _cachedGroups;
    }
}