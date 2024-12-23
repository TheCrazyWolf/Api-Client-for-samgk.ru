using ClientSamgk.Models;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Interfaces.Client;

public interface ISсheduleController
{
    /// <summary>
    /// Получение расписания
    /// </summary>
    /// <param name="query">Запрос, настроенный через <see cref="ScheduleQuery"/></param>
    /// <returns>Список из <see cref="IResultOutScheduleFromDate"/></returns>
    public IList<IResultOutScheduleFromDate> GetSchedule(ScheduleQuery query);

    /// <summary>
    /// Получение расписания
    /// </summary>
    /// <param name="query">Запрос, настроенный через <see cref="ScheduleQuery"/></param>
    /// <param name="cToken">Cancellation token</param>
    /// <returns>Список из <see cref="IResultOutScheduleFromDate"/></returns>
    public Task<IList<IResultOutScheduleFromDate>> GetScheduleAsync(ScheduleQuery query,
        CancellationToken cToken = default);
}