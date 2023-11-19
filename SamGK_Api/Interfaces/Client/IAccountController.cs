using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccountController
{
    IAccount? Authorization(IAuthorizationPacket packet);
    Task<IAccount?> AuthorizationAsync(IAuthorizationPacket packet);

    IEnumerable<IEmployee>? GetEmployees(bool forceLoad = false);
    Task<IEnumerable<IEmployee>?> GetEmployeesAsync(bool forceLoad = false);
}