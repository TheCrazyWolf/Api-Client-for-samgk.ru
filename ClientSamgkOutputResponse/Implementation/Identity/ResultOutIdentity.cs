using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Identity;

public class ResultOutIdentity : IResultOutIdentity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName => GetShortName();

    private string GetShortName()
    {
        var arraysTeacherName = Name.Replace("  ", string.Empty).Replace("  ", string.Empty).Split(' ');
        return arraysTeacherName.Length == 3 ? $"{arraysTeacherName[0]} {arraysTeacherName[1].FirstOrDefault()}. {arraysTeacherName[2].FirstOrDefault()}." : Name;
    }
}