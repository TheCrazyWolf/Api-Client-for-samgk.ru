using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Identity;

public class ResultOutIdentity : IResultOutIdentity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName => GetShortName();
    string GetShortName()
    {
        var teacherNameParts = Name.Split([' '], StringSplitOptions.RemoveEmptyEntries);
        return teacherNameParts.Length >= 3
            ? $"{teacherNameParts[0]} {teacherNameParts[1][0]}. {teacherNameParts[2][0]}."
            : Name;
    }
}