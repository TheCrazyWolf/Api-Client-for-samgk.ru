using ClientSamgk.Interfaces;
using ClientSamgk.Models.Api.Implementation.Cabs;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Utils;
using RestSharp;

namespace ClientSamgk.DataFetchers;

public class CabsDataFetcher(IRestClient client) : IDataFetcher<IResultOutCab>
{
    public async Task<IEnumerable<IResultOutCab>> FetchAsync(CancellationToken cToken = default)
    {
        var resultApiCabs = await client
            .SendRequest<Dictionary<string, string>>(new Uri("https://mfc.samgk.ru/api/cabs"), cToken: cToken)
            .ConfigureAwait(false);

        if (resultApiCabs == null || !resultApiCabs.Any()) return Array.Empty<IResultOutCab>();

        return resultApiCabs
            .Select(IResultOutCab (x) => new ResultOutCab
            {
                Adress = x.Value
            })
            .OrderBy(x => x.Adress);
    }
}