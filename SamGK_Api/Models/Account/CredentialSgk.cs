using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Models.Account;

public class CredentialSgk : ICredentialSgk
{
    public string Username { get; set; }
    public string Password { get; set; }
}