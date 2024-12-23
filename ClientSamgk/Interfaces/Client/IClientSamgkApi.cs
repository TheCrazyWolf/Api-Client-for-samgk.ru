namespace ClientSamgk.Interfaces.Client;

public interface IClientSamgkApi
{
    /// <summary>
    /// Методы с группами.
    /// </summary>
    public IGroupController Groups { get; }

    /// <summary>
    /// Методы с кабинетами.
    /// </summary>
    public ICabController Cabs { get; }

    /// <summary>
    /// Методы с расписанием.
    /// </summary>
    public ISсheduleController Schedule { get; }

    /// <summary>
    /// Методы с преподавателями.
    /// </summary>
    public IIdentityController Accounts { get; }

    /// <summary>
    /// Методы для работы с кэшем.
    /// </summary>
    public IMemoryCacheController Cache { get; }
}