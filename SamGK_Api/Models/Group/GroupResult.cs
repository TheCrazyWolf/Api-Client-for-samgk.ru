using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Models.Group;

public class GroupResult : IGroupResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Currator { get; set; }
}