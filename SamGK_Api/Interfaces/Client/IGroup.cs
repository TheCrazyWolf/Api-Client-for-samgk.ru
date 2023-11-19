using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Interfaces.Client;

public interface IGroup
{
    IEnumerable<IGroupResult>? Get();
    Task<IEnumerable<IGroupResult>?> GetAsync();
}