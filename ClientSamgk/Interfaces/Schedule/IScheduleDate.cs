namespace SamGK_Api.Interfaces.Schedule;

public interface IScheduleDate
{
    /// <summary>
    /// Дата расписания
    /// </summary>
    public string Date { get; set; }
    /// <summary>
    /// Дата расписания представленная в виде DateOnly
    /// </summary>
    public DateOnly DateStructure { get; }
    /* Особое мнение TheCrazyWolf
     *
     * По скольку основной ответ приходит в виде строки
     * вроде бы не горит, но на будущее можно будет
     * получать дату в виде структуры
     */
    
    /// <summary>
    /// Занятия за текущий день в виде массива
    /// </summary>
    public IEnumerable<ILesson> Lessons { get; set; }
}