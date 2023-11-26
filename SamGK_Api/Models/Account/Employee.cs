using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Models.Account;

public class Employee : IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
}