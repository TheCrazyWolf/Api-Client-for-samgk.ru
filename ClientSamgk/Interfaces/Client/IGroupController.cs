using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgk.Interfaces.Client;

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
    IList<IResultOutGroup> GetGroups();

    /// <summary>
    /// Поиск группы по ID
    /// </summary>
    /// <param name="idGroup">ID группы</param>
    /// <returns>Возращает IGroup если все хорошо, если проблемы - null</returns>
    IResultOutGroup? GetGroup(int idGroup);
    /// <summary>
    /// Поиск группы по названию
    /// </summary>
    /// <param name="searchGroup">Название группы</param>
    /// <returns>Возращает IGroup если все хорошо, если проблемы - null</returns>
    IResultOutGroup? GetGroup(string searchGroup);
}