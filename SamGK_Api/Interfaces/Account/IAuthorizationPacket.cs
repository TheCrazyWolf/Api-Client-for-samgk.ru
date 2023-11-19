namespace SamGK_Api.Interfaces.Account;

public interface IAuthorizationPacket
{
    public string Username { get; set; }
    public string Password { get; set; }
}