namespace ClientSamgkOutputResponse.Interfaces.Identity;

public interface IResultOutIdentity
{
    /// <summary>
    /// ID сотрудника
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Фио преподавателя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Короткое имя в формате Фамилия И.О.
    /// </summary>
    public string ShortName { get; }
}