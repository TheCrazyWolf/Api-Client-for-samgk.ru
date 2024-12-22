using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Interfaces.Groups;

public interface IResultOutGroup
{
    /// <summary>
    /// ID группы
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название группы
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ID куратора группы, которые не работает и не совпадает с реальной жизнью
    /// </summary>
    public IResultOutIdentity? Currator { get; set; }

    /// <summary>
    /// № курса обучения
    /// </summary>
    public int Course { get; }
}