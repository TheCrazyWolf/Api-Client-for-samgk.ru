namespace SamGK_Api.Interfaces.Account;

public interface IAccountResult
{
    public int Code { get; set; }
    public string? Group { get; set; }
    public string Fio { get; set; }
}