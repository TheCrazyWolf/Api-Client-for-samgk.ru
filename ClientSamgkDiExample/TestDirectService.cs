using ClientSamgk;
using Microsoft.Extensions.Hosting;

namespace ClientSamgkDiExample;

public class TestDirectService : IHostedService
{
    private readonly ClientSamgkApi _clientSamgk;

    public TestDirectService(ClientSamgkApi clientSamgk)
    {
        _clientSamgk = clientSamgk;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var res = await _clientSamgk.Accounts.GetTeachersAsync();
        Console.WriteLine(res.Count);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}