using SamGK_Api.Interfaces.Cabs;

namespace SamGK_Api.Interfaces.Client;

public interface ICabController
{
    /// <summary>
    /// Возращает список кабинетов
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;ICab&gt; если все хорошо, если проблемы - null</returns>
    IEnumerable<ICab>? GetCabs(bool forceLoad = false);
    /// <summary>
    /// Возращает список кабинетов
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;ICab&gt; если все хорошо, если проблемы - null</returns>
    Task<IEnumerable<ICab>?> GetCabsAsync(bool forceLoad = false);

    /// <summary>
    /// Получение группы по номеру кабинета
    /// </summary>
    /// <param name="cabName">Номер кабинета</param>
    /// <returns>Возращает ICab если все хорошо, если проблемы - null</returns>
    ICab? GetCab(string cabName);
}