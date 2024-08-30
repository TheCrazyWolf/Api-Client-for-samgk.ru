using SamGK_Api.Interfaces.Client;

namespace ClientSamgk.Interfaces.Client;

public interface IMainClient
{
    public ISсheduleController Sсhedule { get; }
    public IAccountController Accounts { get; }
    public IGroupController Groups { get; }
    public ICabController Cabs { get; }

    Task RefreshCache();
}