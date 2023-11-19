using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Interfaces.Client;

public interface IGroup
{
    IEnumerable<IGroupResult>? Get(bool forceLoad = false);
    Task<IEnumerable<IGroupResult>?> GetAsync(bool forceLoad = false);
}