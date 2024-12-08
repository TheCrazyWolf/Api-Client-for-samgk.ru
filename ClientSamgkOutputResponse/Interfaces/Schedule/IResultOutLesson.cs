using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Education;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutLesson
{
    /// <summary>
    /// Список преподавателей ведущий урок
    /// </summary>
    public IList<IResultOutIdentity> Identity { get; set; }
    /// <summary>
    /// Информация о группеы
    /// </summary>
    public IResultOutGroup? EducationGroup { get; set; }
    /// <summary>
    /// Информация о предмете
    /// </summary>
    public IResultOutSubjectItem SubjectDetails { get; set; }
    /// <summary>
    /// Список кабинетов в которых проходят занятия
    /// </summary>
    public IList<IResultOutCab> Cabs { get; set; }
    /// <summary>
    /// Номер пары
    /// </summary>
    public long NumPair { get; set; }
    /// <summary>
    /// Номер урока
    /// </summary>
    public long NumLesson { get; set; }
    /// <summary>
    /// Информация о длительности занятий
    /// </summary>
    public IList<DurationLessonDetails> Durations { get; set; }
    /// <summary>
    /// Дата и время начала урока
    /// </summary>
    [Obsolete("Свойство устарело и будет удалено в ближайшем обновлении. Используйте свойство Durations")]
    public TimeOnly DurationStart { get; set; } 
    /// <summary>
    /// Дата и время конец урока
    /// </summary>
    [Obsolete("Свойство устарело и будет удалено в ближайшем обновлении. Используйте свойство Durations")]
    public TimeOnly DurationEnd { get; set; } 
}