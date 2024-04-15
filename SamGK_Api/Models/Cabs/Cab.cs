using SamGK_Api.Interfaces.Cabs;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SamGK_Api.Models.Cabs;

public class Cab : ICab
{
    public string Name { get; set; }
}