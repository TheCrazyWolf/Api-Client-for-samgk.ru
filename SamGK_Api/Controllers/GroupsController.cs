using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Models.Group;

namespace SamGK_Api.Controllers;

public class GroupsController : _BaseController, IGroupController
{
    private IEnumerable<IGroup>? _cachedGroups;
    
    public IEnumerable<IGroup>? GetGroups(bool forceLoad = false)
    {
        if (_cachedGroups != null && !forceLoad)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeaders(GetHeaders());
        
        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedGroups = JsonConvert.DeserializeObject<IEnumerable<Group>>(result.Content);
        return _cachedGroups;
    }

    public async Task<IEnumerable<IGroup>?> GetGroupsAsync(bool forceLoad = false)
    {
        if (_cachedGroups != null && !forceLoad)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeaders(GetHeaders());
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedGroups = JsonConvert.DeserializeObject<IEnumerable<Group>>(result.Content);
        return _cachedGroups;
    }
}