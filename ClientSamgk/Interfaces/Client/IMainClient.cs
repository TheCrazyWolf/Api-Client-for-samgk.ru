namespace ClientSamgk.Interfaces.Client;

public interface IMainClient
{
    public ISсheduleController Schedule { get; }
    public IGroupController Groups { get; }
    public ICabController Cabs { get; }
}