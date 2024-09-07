using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface ICabController
{
    IList<IResultOutCab> GetCabs();
    IResultOutCab? GetCab(string cabName);
}