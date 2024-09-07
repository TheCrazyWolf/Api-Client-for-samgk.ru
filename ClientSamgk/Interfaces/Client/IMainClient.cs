namespace ClientSamgk.Interfaces.Client;

public interface IMainClient
{
    public ISсheduleController Sсhedule { get; }
    public IGroupController Groups { get; }
    public ICabController Cabs { get; }
}