using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgkOutputResponse.Implementation.Groups;

public class ResultOutGroup : IResultOutGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Currator { get; set; }
}