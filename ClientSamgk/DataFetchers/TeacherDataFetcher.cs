using ClientSamgk.Interfaces;
using ClientSamgk.Models.Api.Implementation.Identity;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Mfc.Teachers;
using ClientSamgk.Utils;
using RestSharp;

namespace ClientSamgk.DataFetchers;

public class TeacherDataFetcher(IRestClient client) : IDataFetcher<IResultOutIdentity>
{
    public async Task<IEnumerable<IResultOutIdentity>> FetchAsync(CancellationToken cToken = default)
    {
        var resultApiTeachers = await client
            .SendRequest<IList<SamgkTeacherApiResult>>(new Uri("https://mfc.samgk.ru/api/teachers"), cToken: cToken)
            .ConfigureAwait(false);

        if (resultApiTeachers == null || !resultApiTeachers.Any())
            return Array.Empty<IResultOutIdentity>();

        return resultApiTeachers
            .Select(IResultOutIdentity (x) => new ResultOutIdentity
            {
                Id = Convert.ToInt64(x.Id),
                Name = x.Name
            })
            .OrderBy(x => x.Name);
    }
}