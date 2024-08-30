namespace ClientSamgkOutputResponse.Interfaces.Education;

public interface IResultOutSubjectItem
{
    /// <summary>
    /// ID дисциплины
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название дисциплины
    /// </summary>
    public string SubjectName { get; set; }
}