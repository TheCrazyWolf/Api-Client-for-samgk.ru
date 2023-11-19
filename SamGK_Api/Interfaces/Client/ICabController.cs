using SamGK_Api.Interfaces.Cabs;

namespace SamGK_Api.Interfaces.Client;

public interface ICabController
{
    IEnumerable<ICab>? GetCabs(bool forceLoad = false);
    Task<IEnumerable<ICab>?> GetCabsAsync(bool forceLoad = false);
}