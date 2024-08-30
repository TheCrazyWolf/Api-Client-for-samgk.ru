using SamGK_Api.Interfaces.Groups;

namespace SamGK_Api.Interfaces.Client;

public interface IGroupController
{
    /// <summary>
    /// Получение список групп
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;IGroup&gt; если все хорошо, если проблемы - null</returns>
    IList<IGroup> GetGroups(bool forceLoad = false);
    /// <summary>
    /// Получение список групп
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;IGroup&gt; если все хорошо, если проблемы - null</returns>
    Task<IList<IGroup>> GetGroupsAsync(bool forceLoad = false);

    /// <summary>
    /// Поиск группы по ID
    /// </summary>
    /// <param name="idGroup">ID группы</param>
    /// <returns>Возращает IGroup если все хорошо, если проблемы - null</returns>
    IGroup? GetGroup(int idGroup);
    /// <summary>
    /// Поиск группы по названию
    /// </summary>
    /// <param name="searchGroup">Название группы</param>
    /// <returns>Возращает IGroup если все хорошо, если проблемы - null</returns>
    IGroup? GetGroup(string searchGroup);
}