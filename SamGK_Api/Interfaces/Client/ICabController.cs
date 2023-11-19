using SamGK_Api.Interfaces.Cabs;

namespace SamGK_Api.Interfaces.Client;

public interface ICabController
{
    IEnumerable<ICab>? Get(bool forceLoad = false);
    Task<IEnumerable<ICab>?> GetAsync(bool forceLoad = false);
}