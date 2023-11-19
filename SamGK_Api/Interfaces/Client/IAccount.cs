using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccount
{
    IAccountResult? Authorization(IAuthorizationPacket packet);
    Task<IAccountResult?> AuthorizationAsync(IAuthorizationPacket packet);

    IEnumerable<IEmployee>? GetEmployees(bool forceLoad = false);
    Task<IEnumerable<IEmployee>?> GetEmployeesAsync(bool forceLoad = false);
}