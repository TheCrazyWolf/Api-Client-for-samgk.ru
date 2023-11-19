using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Interfaces.Client;

public interface IGroupController
{
    IEnumerable<IGroup>? GetGroups(bool forceLoad = false);
    Task<IEnumerable<IGroup>?> GetGroupsAsync(bool forceLoad = false);
}