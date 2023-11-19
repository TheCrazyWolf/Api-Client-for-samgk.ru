namespace SamGK_Api.Interfaces.Account;

public interface IAccount
{
    public int Code { get; set; }
    public string? Group { get; set; }
    public string Fio { get; set; }
}