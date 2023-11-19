namespace SamGK_Api.Interfaces.Groups;

public interface IGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Currator { get; set; }
}