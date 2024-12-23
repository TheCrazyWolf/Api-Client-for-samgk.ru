using ClientSamgkOutputResponse.Enums;

namespace ClientSamgkOutputResponse.Interfaces.Schedule;

public interface IResultOutScheduleFromDate
{
    /// <summary>
    /// Дата.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Коллекция занятия.
    /// </summary>
    public IList<IResultOutLesson> Lessons { get; set; }

    /// <summary>
    /// Тип поиска.
    /// </summary>
    public ScheduleSearchType SearchType { get; set; }

    /// <summary>
    /// Что ищем.
    /// </summary>
    public string IdValue { get; set; }

    /// <summary>
    /// Типы звонков.
    /// </summary>
    public ScheduleCallType CallType { get; set; }
}