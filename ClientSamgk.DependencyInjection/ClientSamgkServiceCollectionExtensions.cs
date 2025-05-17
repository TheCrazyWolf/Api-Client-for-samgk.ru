using ClientSamgk;
using ClientSamgk.Cache;
using ClientSamgk.Cache.Memory;
using ClientSamgk.Controllers;
using ClientSamgk.DataFetchers;
using ClientSamgk.Interfaces;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using ClientSamgk.Models.Params.Implementations.Cache;
using ClientSamgk.Models.Params.Interfaces.Cache;
using RestSharp;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up ClientSamgk related services in an <see cref="IServiceCollection" />.
/// </summary>
public static class ClientSamgkServiceCollectionExtensions
{
    private static readonly IReadOnlyList<(Type, Type)> CacheTypes = new[]
    {
        (typeof(IResultOutIdentity), typeof(TeacherDataFetcher)),
        (typeof(IResultOutGroup), typeof(GroupDataFetcher)),
        (typeof(IResultOutCab), typeof(CabsDataFetcher))
    };

    private static readonly IReadOnlyList<(Type, Type)> ControllersTypes = new[]
    {
        (typeof(IIdentityController), typeof(AccountController)),
        (typeof(IGroupController), typeof(GroupsController)),
        (typeof(ICabController), typeof(CabsController)),
        (typeof(ISсheduleController), typeof(ScheduleController)),
        (typeof(IMemoryCacheController), typeof(MemoryCacheController)),
    };

    public static IServiceCollection AddClientSamgk(this IServiceCollection serviceCollection) =>
        AddClientSamgk(serviceCollection, _ => { });

    public static IServiceCollection AddClientSamgk(this IServiceCollection serviceCollection,
        Action<CacheOptions> cacheOptionSetupFactory)
    {
        serviceCollection.AddSingleton<IRestClient>(_ => new RestClient(new HttpClient()));

        var cacheOptions = new CacheOptions();
        cacheOptionSetupFactory.Invoke(cacheOptions);
        serviceCollection.AddSingleton<ICacheOptions>(cacheOptions);

        // Add all types of cache entries to DI
        foreach (var type in CacheTypes)
        {
            // Cache with memory storage (TODO: make option to change type of cache)
            serviceCollection.Add(
                new ServiceDescriptor(
                    typeof(ICache<>).MakeGenericType(type.Item1),
                    typeof(MemoryCache<>).MakeGenericType(type.Item1),
                    ServiceLifetime.Singleton)
            );

            // Cache data fetcher
            serviceCollection.Add(
                new ServiceDescriptor(
                    typeof(IDataFetcher<>).MakeGenericType(type.Item1),
                    type.Item2,
                    ServiceLifetime.Scoped)
            );

            // Cache manager
            serviceCollection
                .AddScoped(typeof(CacheManager<>).MakeGenericType(type.Item1));
        }

        var scheduleResType = typeof(IResultOutScheduleFromDate);
        serviceCollection.Add(
            new ServiceDescriptor(
                typeof(ICache<>).MakeGenericType(scheduleResType),
                typeof(MemoryCache<>).MakeGenericType(scheduleResType),
                ServiceLifetime.Singleton)
        );

        foreach (var types in ControllersTypes)
        {
            serviceCollection.Add(
                new ServiceDescriptor(
                    types.Item1,
                    types.Item2,
                    ServiceLifetime.Scoped)
            );
        }

        serviceCollection.AddScoped<ClientSamgkApi>();

        return serviceCollection;
    }
}