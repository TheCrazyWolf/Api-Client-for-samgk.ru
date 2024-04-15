using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Models.Group;

namespace SamGK_Api.Controllers;

public class GroupsController : BaseController, IGroupController
{
    private IEnumerable<IGroup>? _cachedGroups;
    
    public IEnumerable<IGroup>? GetGroups(bool forceLoad = false)
    {
        return GetGroupsAsync(forceLoad: forceLoad).GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<IGroup>?> GetGroupsAsync(bool forceLoad = false)
    {
        if (_cachedGroups != null && !forceLoad)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups", Method.Get);
        options.AddHeaders(GetHeaders());
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedGroups = JsonConvert.DeserializeObject<IEnumerable<Group>>(result.Content);
        return _cachedGroups;
    }

    public IGroup? GetGroup(int idGroup)
    {
        _cachedGroups ??= GetGroups();
        return _cachedGroups?.FirstOrDefault(group => group.Id == idGroup);
    }

    public IGroup? GetGroup(string searchGroup)
    {
        _cachedGroups ??= GetGroups();
        return _cachedGroups?.FirstOrDefault(group => group.Name.ToUpper() == searchGroup.ToUpper());
    }
}