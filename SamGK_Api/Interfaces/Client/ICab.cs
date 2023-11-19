using SamGK_Api.Interfaces.Cabs;

namespace SamGK_Api.Interfaces.Client;

public interface ICab
{
    IEnumerable<ICabsResult>? Get(bool forceLoad = false);
    Task<IEnumerable<ICabsResult>?> GetAsync(bool forceLoad = false);
}