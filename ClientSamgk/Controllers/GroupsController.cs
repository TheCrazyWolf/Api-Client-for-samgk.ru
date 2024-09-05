using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Groups;
using SamGK_Api.Interfaces.Client;

namespace ClientSamgk.Controllers;

public class GroupsController : CommonSamgkController, IGroupController
{
    public IList<IResultOutGroup> GetGroups()
    {
        return CachesGroups;
    }

    public IResultOutGroup? GetGroup(int idGroup)
    {
        return CachesGroups.FirstOrDefault(x=> x.Id == idGroup);
    }

    public IResultOutGroup? GetGroup(string searchGroup)
    {
        return CachesGroups.FirstOrDefault(x=> string.Equals(x.Name, searchGroup, 
            StringComparison.CurrentCultureIgnoreCase));
    }
}