using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Interfaces.Client;

public interface IGroupController
{
    IEnumerable<IGroup>? Get(bool forceLoad = false);
    Task<IEnumerable<IGroup>?> GetAsync(bool forceLoad = false);
}