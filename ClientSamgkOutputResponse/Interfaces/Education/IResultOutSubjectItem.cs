namespace ClientSamgkOutputResponse.Interfaces.Education;

public interface IResultOutSubjectItem
{
    /// <summary>
    /// ID дисциплины
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Название дисциплины
    /// </summary>
    public string SubjectName { get; set; }
}