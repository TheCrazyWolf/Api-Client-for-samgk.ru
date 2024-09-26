using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface ICabController
{
    IList<IResultOutCab> GetCabs();
    Task<IList<IResultOutCab>> GetCabsAsync();
    IResultOutCab? GetCab(string cabName);
    Task<IResultOutCab?> GetCabAsync(string cabName);
    Task<IList<IResultOutCab>> GetCabsAsync(string campusNumber);
    IList<IResultOutCab> GetCabs(string campusNumber);
    public IList<string> GetCampuses();
    public Task<IList<string>> GetCampusesAsync();
    public Task<IList<IResultOutCab>> GetCabsFromCampusAsync(string campusName);
    public IList<IResultOutCab> GetCabsFromCampus(string campusName);
}