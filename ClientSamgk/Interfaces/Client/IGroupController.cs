using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgk.Interfaces.Client;

public interface IGroupController
{
    /// <summary>
    /// Получить список групп
    /// </summary>
    /// <returns>Коллекция объектов реализующий интерфейс IResultOutGroup</returns>
    IList<IResultOutGroup> GetGroups();
    /// <summary>
    /// Получить список групп
    /// </summary>
    /// <returns>Коллекция объектов реализующий интерфейс IResultOutGroup</returns>
    Task<IList<IResultOutGroup>> GetGroupsAsync();
    /// <summary>
    /// Получить группу по ID
    /// </summary>
    /// <param name="idGroup">ID группы</param>
    /// <returns>Объект реализующий интерфейс IResultOutGroup, null - если ничего не нашлось</returns>
    IResultOutGroup? GetGroup(int idGroup);
    /// <summary>
    /// Получить группу по ID
    /// </summary>
    /// <param name="idGroup">ID группы</param>
    /// <returns>Объект реализующий интерфейс IResultOutGroup, null - если ничего не нашлось</returns>
    Task<IResultOutGroup?> GetGroupAsync(int idGroup);
    /// <summary>
    /// Поиск группы по Названию
    /// </summary>
    /// <param name="searchGroup">Например, ИС-23-01</param>
    /// <returns>Объект реализующий интерфейс IResultOutGroup, null - если ничего не нашлось</returns>
    IResultOutGroup? GetGroup(string searchGroup);
    /// <summary>
    /// Поиск группы по Названию
    /// </summary>
    /// <param name="searchGroup">Например, ИС-23-01</param>
    /// <returns>Объект реализующий интерфейс IResultOutGroup, null - если ничего не нашлось</returns>
    Task<IResultOutGroup?> GetGroupAsync(string searchGroup);
}