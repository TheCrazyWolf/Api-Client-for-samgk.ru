using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface ICabController
{
    IList<IResultOutCab> GetCabs();
    Task<IList<IResultOutCab>> GetCabsAsync();
    IResultOutCab? GetCab(string cabName);
    Task<IResultOutCab?> GetCabAsync(string cabName);
    Task<IList<IResultOutCab>> GetCabsAsync(int campusNumber);
    IList<IResultOutCab> GetCabs(int campusNumber);
}