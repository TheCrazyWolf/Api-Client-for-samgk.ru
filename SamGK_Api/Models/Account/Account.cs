using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Models.Account;

public class Account : IAccount
{
    public int Code { get; set; }
    public string? Group { get; set; }
    public string Fio { get; set; }
}