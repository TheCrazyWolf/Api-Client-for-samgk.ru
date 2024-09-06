using SamGK_Api.Interfaces.Groups;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SamGK_Api.Models.Group;

public class Group : IGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Currator { get; set; }
}