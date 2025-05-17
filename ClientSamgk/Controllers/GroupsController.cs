using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Groups;

namespace ClientSamgk.Controllers;

public class GroupsController(CacheManager<IResultOutGroup> groupsCacheManager) : IGroupController
{
    public IList<IResultOutGroup> GetGroups()
    {
        return GetGroupsAsync().GetAwaiter().GetResult();
    }

    public async Task<IList<IResultOutGroup>> GetGroupsAsync()
    {
        await groupsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return groupsCacheManager.Data.Select(x => x.Object).OrderBy(x => x.Name).ToList();
    }

    public IResultOutGroup? GetGroup(long idGroup)
    {
        return GetGroupAsync(idGroup).GetAwaiter().GetResult();
    }

    public async Task<IResultOutGroup?> GetGroupAsync(long idGroup)
    {
        await groupsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return groupsCacheManager.Data.Select(x => x.Object).FirstOrDefault(x => x.Id == idGroup);
    }

    public IResultOutGroup? GetGroup(string searchGroup)
    {
        return GetGroupAsync(searchGroup).GetAwaiter().GetResult();
    }

    public async Task<IResultOutGroup?> GetGroupAsync(string searchGroup)
    {
        await groupsCacheManager.EnsureCacheAsync().ConfigureAwait(false);
        return groupsCacheManager.Data.Select(x => x.Object).FirstOrDefault(x =>
            string.Equals(x.Name, searchGroup, StringComparison.CurrentCultureIgnoreCase));
    }
}