using ClientSamgkOutputResponse.Interfaces.Groups;

namespace ClientSamgk.Interfaces.Client;

public interface IGroupController
{
    IList<IResultOutGroup> GetGroups();
    Task<IList<IResultOutGroup>> GetGroupsAsync();
    IResultOutGroup? GetGroup(int idGroup);
    Task<IResultOutGroup?> GetGroupAsync(int idGroup);
    IResultOutGroup? GetGroup(string searchGroup);
    Task<IResultOutGroup?> GetGroupAsync(string searchGroup);
}