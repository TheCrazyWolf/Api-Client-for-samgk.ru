using ClientSamgk.Controllers;
using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Models.Group;

namespace SamGK_Api.Controllers;

public class GroupsController : BaseController, IGroupController
{
    private IList<IGroup>? _cachedGroups;
    
    public IList<IGroup> GetGroups(bool forceLoad = false)
    {
        return GetGroupsAsync(forceLoad: forceLoad).GetAwaiter().GetResult();
    }

    public async Task<IList<IGroup>> GetGroupsAsync(bool forceLoad = false)
    {
        if (_cachedGroups != null && !forceLoad)
            return _cachedGroups;
        
        var options = new RestRequest("https://mfc.samgk.ru/api/groups");
        options.AddHeaders(GetHeaders());
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return _cachedGroups ?? new List<IGroup>();

        _cachedGroups = JsonConvert.DeserializeObject<IList<Group>>(result.Content)?.Cast<IGroup>().ToList();
        return _cachedGroups ?? new List<IGroup>();
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