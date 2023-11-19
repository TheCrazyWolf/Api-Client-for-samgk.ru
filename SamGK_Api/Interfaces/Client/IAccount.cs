using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccount
{
    IAccountResult Authorization(IAuthorizationPacket packet);
    IAccountResult AuthorizationAsync(IAuthorizationPacket packet);
}