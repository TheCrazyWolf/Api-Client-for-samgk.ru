using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;

namespace SamGK_Api.Interfaces.Client;

public interface ISсheduleController
{
    /// <summary>
    /// Получение расписание за определенный день
    /// сотрудника
    /// </summary>
    /// <param name="date">Дата и время</param>
    /// <param name="entity">Интерфейс сотрудника</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly date, IEmployee entity);
    /// <summary>
    /// Получение расписание за определенный день
    /// сотрудника
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="entity">Интерфейс сотрудника</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, IEmployee entity);
    /// <summary>
    /// Получение расписание за диапазон
    /// сотрудника
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс сотрудника</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, IEmployee entity, int delay = 700);
    /// <summary>
    /// Получение расписание за диапазон
    /// сотрудника
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс сотрудника</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IEmployee entity, int delay = 700);
    /// <summary>
    /// Получение расписание за конкретный день
    /// группы
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly date, IGroup entity);
    /// <summary>
    /// Получение расписание за конкретный день
    /// группы
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, IGroup entity);
    /// <summary>
    /// Получение расписание за диапозон
    /// группы
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700);
    /// <summary>
    /// Получение расписание за диапозон
    /// группы
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700);
    /// <summary>
    /// Получение расписание за конкретный день
    /// по кабинету
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="entity">Интерфейс кабинета</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly date, ICab entity);
    /// <summary>
    /// Получение расписание за конкретный день
    /// по кабинету
    /// </summary>
    /// <param name="date">Дата</param>
    /// <param name="entity">Интерфейс кабинета</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, ICab entity);
    /// <summary>
    /// Получение расписание за диапозон
    /// по кабинету
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700);
    /// <summary>
    /// Получение расписание за диапозон
    /// по кабинету
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="entity">Интерфейс группы</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700);

    /// <summary>
    /// Получение расписание за конкретный день
    /// с помощью перечисления SheduleSearchType
    /// </summary>
    /// <param name="date">Дата получения расписание</param>
    /// <param name="type">Перечисление
    /// SheduleSearchType.Employee - расписание сотрудника
    /// SheduleSearchType.Group - расписание по группе
    /// SheduleSearchType.Cab - расписание по кабинету
    /// </param>
    /// <param name="id">ID сотрудника, кабинета, группы в формате строки</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly date, SheduleSearchType type, string id);
    /// <summary>
    /// Получение расписание за конкретный день
    /// с помощью перечисления SheduleSearchType
    /// </summary>
    /// <param name="date">Дата получения расписание</param>
    /// <param name="type">Перечисление
    /// SheduleSearchType.Employee - расписание сотрудника
    /// SheduleSearchType.Group - расписание по группе
    /// SheduleSearchType.Cab - расписание по кабинету
    /// </param>
    /// <param name="id">ID сотрудника, кабинета, группы в формате строки</param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly date, SheduleSearchType type, string id);
    /// <summary>
    /// Получение расписание за конкретный день
    /// с помощью перечисления SheduleSearchType
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="type">Перечисление
    /// SheduleSearchType.Employee - расписание сотрудника
    /// SheduleSearchType.Group - расписание по группе
    /// SheduleSearchType.Cab - расписание по кабинету
    /// </param>
    /// <param name="id">ID сотрудника, кабинета, группы в формате строки</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    IEnumerable<IScheduleDate> GetSchedule(DateOnly startDate, DateOnly endDate, SheduleSearchType type, string id, int delay = 700);
    /// <summary>
    /// Получение расписание за конкретный день
    /// с помощью перечисления SheduleSearchType
    /// </summary>
    /// <param name="startDate">С какой даты</param>
    /// <param name="endDate">По какую дату</param>
    /// <param name="type">Перечисление
    /// SheduleSearchType.Employee - расписание сотрудника
    /// SheduleSearchType.Group - расписание по группе
    /// SheduleSearchType.Cab - расписание по кабинету
    /// </param>
    /// <param name="id">ID сотрудника, кабинета, группы в формате строки</param>
    /// <param name="delay">Имитация задержки, используйте вне сети колледжа, чтобы не получить блокировку. Необязательный параметр
    /// Default value = 700
    /// </param>
    /// <returns>IEnumerable&lt;IScheduleDate&gt;
    /// Если расписание за этот день есть,
    /// если нет - null
    /// </returns>
    Task<IEnumerable<IScheduleDate>> GetScheduleAsync(DateOnly startDate, DateOnly endDate, SheduleSearchType type, string id, int delay = 700);
}

public enum SheduleSearchType
{
    Employee, Group, Cab
}