namespace ClientSamgk.Models.Params.Interfaces.Cache;

public interface ICacheOptions
{
    /// <summary>
    /// Срок жизни общих объектов (списки преподавателей, групп, кабинетов.
    /// в минутах
    /// </summary>
    int LifeTimeObjectsForCommon { get; set; }

    /// <summary>
    /// Срок жизни долгих и не меняющихся объектов (например прошедшее расписание)
    /// в минутах
    /// </summary>
    int LifeTimeObjectsForLong { get; set; }

    /// <summary>
    /// Срок жизни часто меняющихся объектов (например, расписание на сегодня и последующие дни)
    /// в минутах
    /// </summary>
    int LifeTimeObjectsForShort { get; set; }
}