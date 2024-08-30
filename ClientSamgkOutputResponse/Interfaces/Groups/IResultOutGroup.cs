namespace ClientSamgkOutputResponse.Interfaces.Groups;

public interface IResultOutGroup
{
    /// <summary>
    /// ID группы
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название группы
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// ID куратора группы, которые не работает и не совпадает с реальной жизнью
    /// </summary>
    public int? Currator { get; set; }
}