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
    IResultOutIdentity? GetTeacher(long id);
    Task<IResultOutIdentity?> GetTeacherAsync(long id);
    /// <summary>
    /// Поиск преподавателя по ФИО
    /// </summary>
    /// <param name="teacherName">например, Иванов Иван Иванович</param>
    /// <returns>Объект реализующий интерфейс IResultOutIdentity, null - если ничего не нашлось</returns>
    Task<IResultOutIdentity?> GetTeacherAsync(string teacherName);
}