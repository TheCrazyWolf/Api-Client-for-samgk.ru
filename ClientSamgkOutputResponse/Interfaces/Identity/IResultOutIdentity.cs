namespace ClientSamgkOutputResponse.Interfaces.Identity;

public interface IResultOutIdentity
{
    /// <summary>
    /// ID сотрудника
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Фио преподавателя
    /// </summary>
    public string Name { get; set; }
}