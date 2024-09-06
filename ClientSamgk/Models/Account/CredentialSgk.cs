using SamGK_Api.Interfaces.Account;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SamGK_Api.Models.Account;

public class CredentialSgk : ICredentialSgk
{
    public string Username { get; set; }
    public string Password { get; set; }
}