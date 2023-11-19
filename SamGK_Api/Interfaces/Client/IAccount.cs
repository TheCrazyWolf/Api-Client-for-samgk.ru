using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccount
{
    IAccountResult? Authorization(IAuthorizationPacket packet);
    Task<IAccountResult?> AuthorizationAsync(IAuthorizationPacket packet);

    IEnumerable<IEmployee>? GetEmployees();
    Task<IEnumerable<IEmployee>?> GetEmployeesAsync(IAuthorizationPacket packet);
}