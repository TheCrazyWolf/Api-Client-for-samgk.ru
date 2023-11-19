namespace SamGK_Api.Interfaces.Account;

public interface IAuthorizationPacket
{
    public string Login { get; set; }
    public string Password { get; set; }
}