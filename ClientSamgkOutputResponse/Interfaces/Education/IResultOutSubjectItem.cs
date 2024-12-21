namespace ClientSamgkOutputResponse.Interfaces.Education;

public interface IResultOutSubjectItem
{
    /// <summary>
    /// ID дисциплины.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Индекс дисциплины.
    /// </summary>
    public string Index { get; set; }
    
    /// <summary>
    /// Короткое название дисциплины.
    /// </summary>
    public string SubjectName { get; set; }

    /// <summary>
    /// Название дисциплины Полностью.
    /// </summary>
    public string FullSubjectName { get; }
    
    /// <summary>
    /// Является ли эта дисциплина зачётом.
    /// </summary>
    public bool IsAttestation { get; set; }
}