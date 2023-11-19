using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Models.Group;

public class Group : IGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Currator { get; set; }
}