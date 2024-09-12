using ClientSamgk.Common;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Controllers;

public class AccountController : CommonSamgkController, IIdentityController
{
    public IList<IResultOutIdentity> GetTeachers()
    {
        return CachedIdentities.OrderBy(x=> x.Name).ToList();
    }

    public IResultOutIdentity? GetTeacher(string teacherName)
    {
        return CachedIdentities.FirstOrDefault(x=> string.Equals(x.Name, teacherName, 
            StringComparison.CurrentCultureIgnoreCase));
    }
}