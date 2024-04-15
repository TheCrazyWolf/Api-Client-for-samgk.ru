using SamGK_Api.Interfaces.Account;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SamGK_Api.Models.Account;

public class Employee : IEmployee
{
    public long Id { get; set; }
    public string Name { get; set; }
}