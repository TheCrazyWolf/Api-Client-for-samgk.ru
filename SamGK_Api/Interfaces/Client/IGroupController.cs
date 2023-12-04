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
    IEnumerable<IGroup>? GetGroups(bool forceLoad = false);
    /// <summary>
    /// Получение список групп
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;IGroup&gt; если все хорошо, если проблемы - null</returns>
    Task<IEnumerable<IGroup>?> GetGroupsAsync(bool forceLoad = false);
}