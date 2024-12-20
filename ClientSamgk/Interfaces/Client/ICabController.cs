using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface ICabController
{
    /// <summary>
    /// Получить список кабинетов.
    /// </summary>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    IList<IResultOutCab> GetCabs();

    /// <summary>
    /// Получить список кабинетов.
    /// </summary>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    Task<IList<IResultOutCab>> GetCabsAsync();

    /// <summary>
    /// Получить объект кабинета.
    /// </summary>
    /// <param name="cabName">Номер кабинета, пример 5/515.</param>
    /// <returns>Возращает объект IResultOutCab, null - если не нашлось</returns>
    IResultOutCab? GetCab(string cabName);

    /// <summary>
    /// Получить объект кабинета.
    /// </summary>
    /// <param name="cabName">Номер кабинета, пример 5/515</param>
    /// <returns>Возращает объект IResultOutCab, null - если не нашлось</returns>
    Task<IResultOutCab?> GetCabAsync(string cabName);

    /// <summary>
    /// Получить список кабинетов.
    /// </summary>
    /// <param name="campusNumber">Номер корпуса, например 5</param>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    Task<IList<IResultOutCab>> GetCabsAsync(string campusNumber);

    /// <summary>
    /// Получить список кабинетов.
    /// </summary>
    /// <param name="campusNumber">Номер корпуса, например 5</param>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    IList<IResultOutCab> GetCabs(string campusNumber);

    /// <summary>
    /// Получить список корпусов.
    /// </summary>
    /// <returns>Возращает коллекцию корпусов в виде строк</returns>
    public IList<string> GetCampuses();

    /// <summary>
    /// Получить список корпусов
    /// </summary>
    /// <returns>Возращает коллекцию корпусов в виде строк</returns>
    public Task<IList<string>> GetCampusesAsync();

    /// <summary>
    /// Получить кабинетов по корпусу.
    /// </summary>
    /// <param name="campusName">Номер корпуса, например 5</param>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    public Task<IList<IResultOutCab>> GetCabsFromCampusAsync(string campusName);

    /// <summary>
    /// Получить кабинетов по корпусу.
    /// </summary>
    /// <param name="campusName">Номер корпуса, например 5</param>
    /// <returns>Коллекция объектов реализующих интерфейс IResultOutCab</returns>
    public IList<IResultOutCab> GetCabsFromCampus(string campusName);
}