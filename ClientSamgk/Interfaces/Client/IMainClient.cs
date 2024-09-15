namespace ClientSamgk.Interfaces.Client;

public interface IMainClient
{
    public IGroupController Groups { get; }
    public ICabController Cabs { get; }
    public ISсheduleController Schedule { get; }
    public IIdentityController Accounts { get; }
}