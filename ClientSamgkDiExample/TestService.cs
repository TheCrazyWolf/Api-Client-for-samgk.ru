using ClientSamgk.Cache;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Identity;
using Microsoft.Extensions.Hosting;

namespace ClientSamgkDiExample;

public class TestService : IHostedService
{
    private readonly IIdentityController _teachersApi;
    private readonly ICache<IResultOutIdentity> _teachersCache;

    public TestService(IIdentityController teachersApi, ICache<IResultOutIdentity> teachersCache)
    {
        _teachersApi = teachersApi;
        _teachersCache = teachersCache;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var res = await _teachersApi.GetTeachersAsync();
        Console.WriteLine(res.Count);
        Console.WriteLine(_teachersCache.Data.Count);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}