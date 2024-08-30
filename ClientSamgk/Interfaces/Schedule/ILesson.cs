namespace SamGK_Api.Interfaces.Schedule;

public interface ILesson
{
    /// <summary>
    /// Номер пары, пол пары
    /// </summary>
    public string? Num { get; set; }
    /// <summary>
    /// Название дисциплины
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// Преподаватель, сотрудник его ФИО
    /// </summary>
    public string? Teachername { get; set; }
    /// <summary>
    /// Номер группы
    /// </summary>
    public string? NameGroup { get; set; }
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string? Cab { get; set; }
    /// <summary>
    /// Электронные ресурсы для обучения
    /// </summary>
    public string? Resource { get; set; }
}