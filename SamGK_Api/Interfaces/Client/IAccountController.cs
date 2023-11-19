using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccountController
{
    IAccount? Authorization(ICredentialSgk packet);
    Task<IAccount?> AuthorizationAsync(ICredentialSgk packet);

    IEnumerable<IEmployee>? GetEmployees(bool forceLoad = false);
    Task<IEnumerable<IEmployee>?> GetEmployeesAsync(bool forceLoad = false);
}