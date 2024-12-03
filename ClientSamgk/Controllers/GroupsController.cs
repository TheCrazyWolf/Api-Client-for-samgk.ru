using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgk.Controllers;

public class GroupsController : CommonSamgkController, IGroupController
{
    public IList<IResultOutGroup> GetGroups()
    {
        return GetGroupsAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutGroup>> GetGroupsAsync()
    {
        await UpdateIfCacheIsOutdated();
        return CachesGroups.OrderBy(x=> x.Name).ToList();
    }

    public IResultOutGroup? GetGroup(long idGroup)
    {
        return GetGroupAsync(idGroup).GetAwaiter().GetResult();
    }

    public async Task<IResultOutGroup?> GetGroupAsync(long idGroup)
    {
        await UpdateIfCacheIsOutdated();
        return CachesGroups.FirstOrDefault(x=> x.Id == idGroup);
    }

    public IResultOutGroup? GetGroup(string searchGroup)
    {
        return GetGroupAsync(searchGroup).GetAwaiter().GetResult();
    }

    public async Task<IResultOutGroup?> GetGroupAsync(string searchGroup)
    {
        await UpdateIfCacheIsOutdated();
        return CachesGroups.FirstOrDefault(x=> string.Equals(x.Name, searchGroup, 
            StringComparison.CurrentCultureIgnoreCase));
    }
}