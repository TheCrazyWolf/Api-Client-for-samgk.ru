using ClientSamgkDiExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddClientSamgk();
/*builder.Services.AddClientSamgk(b =>
{
    b.LifeTimeObjectsForCommon = 20;
});*/
builder.Services.AddHostedService<TestService>();
builder.Services.AddHostedService<TestDirectService>();

var host = builder.Build();
await host.RunAsync();