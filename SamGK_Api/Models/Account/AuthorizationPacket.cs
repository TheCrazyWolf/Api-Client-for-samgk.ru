using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Models.Account;

public class AuthorizationPacket : IAuthorizationPacket
{
    public string Login { get; set; }
    public string Password { get; set; }
}