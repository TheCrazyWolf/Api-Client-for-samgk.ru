using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgk.Interfaces.Client;

public interface IGroupController
{
    IList<IResultOutGroup> GetGroups();
    IResultOutGroup? GetGroup(int idGroup);
    IResultOutGroup? GetGroup(string searchGroup);
}