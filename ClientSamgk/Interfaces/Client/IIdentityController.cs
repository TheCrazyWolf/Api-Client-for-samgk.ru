using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Interfaces.Client;

public interface IIdentityController
{
    IList<IResultOutIdentity> GetTeachers();
}