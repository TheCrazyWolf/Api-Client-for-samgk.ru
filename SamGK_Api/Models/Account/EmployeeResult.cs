using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Models.Account;

public class EmployeeResult : IEmployee
{
    public int Id { get; set; }
    public string name { get; set; }
}