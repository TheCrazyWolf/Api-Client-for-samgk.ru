using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Interfaces.Client;

public interface IIdentityController
{
    /// <summary>
    /// Получить список преподавателей
    /// </summary>
    /// <returns>Коллекцию объектов реализующих интерфейс IResultOutIdentity</returns>
    IList<IResultOutIdentity> GetTeachers();
    /// <summary>
    /// Получить список преподавателей
    /// </summary>
    /// <returns>Коллекцию объектов реализующих интерфейс IResultOutIdentity</returns>
    Task<IList<IResultOutIdentity>> GetTeachersAsync();
    /// <summary>
    /// Поиск преподавателя по ФИО
    /// </summary>
    /// <param name="teacherName">например, Иванов Иван Иванович</param>
    /// <returns>Объект реализующий интерфейс IResultOutIdentity, null - если ничего не нашлось</returns>
    IResultOutIdentity? GetTeacher(string teacherName);
    /// <summary>
    /// Поиск преподавателя по ID
    /// </summary>
    /// <param name="id">id преподавателя</param>
    /// <returns>Объект реализующий интерфейс IResultOutIdentity, null - если ничего не нашлось</returns>
    IResultOutIdentity? GetTeacher(long id);
    /// <summary>
    /// Поиск преподавателя по ID
    /// </summary>
    /// <param name="id">id преподавателя</param>
    /// <returns>Объект реализующий интерфейс IResultOutIdentity, null - если ничего не нашлось</returns>
    Task<IResultOutIdentity?> GetTeacherAsync(long id);
    /// <summary>
    /// Поиск преподавателя по ФИО
    /// </summary>
    /// <param name="teacherName">например, Иванов Иван Иванович</param>
    /// <returns>Объект реализующий интерфейс IResultOutIdentity, null - если ничего не нашлось</returns>
    Task<IResultOutIdentity?> GetTeacherAsync(string teacherName);
}