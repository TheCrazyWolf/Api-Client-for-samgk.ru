using ClientSamgk.Models;
using ClientSamgk.Utils;
using ClientSamgkApiModelResponse.Groups;
using ClientSamgkApiModelResponse.Teachers;
using ClientSamgkOutputResponse.Implementation.Cabs;
using ClientSamgkOutputResponse.Implementation.Groups;
using ClientSamgkOutputResponse.Implementation.Identity;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using Newtonsoft.Json;
using RestSharp;

namespace ClientSamgk.Common;

public class CommonSamgkController : CommonCache
{
    private readonly RestClient _client = new(new HttpClient());

    private async Task<RestResponse?> SendRequestAndGetResponse(Uri url, Method method = Method.Get,
        object? body = null, CancellationToken cToken = default)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        if (body is not null && method is Method.Post or Method.Put) options.AddBody(body);
        return await _client.ExecuteAsync(options, method, cToken).ConfigureAwait(false);
    }


    protected async Task<T?> SendRequest<T>(Uri url, Method method = Method.Get, object? body = null, CancellationToken cToken = default)
    {
        var restResponse = await SendRequestAndGetResponse(url, method, body, cToken).ConfigureAwait(false);
        if (restResponse is null || !restResponse.IsSuccessStatusCode || restResponse.Content == null) return default;
        return TryDeserializeObjectOrGetDefault<T>(restResponse.Content);
    }

    private T? TryDeserializeObjectOrGetDefault<T>(string restResponseContent)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(restResponseContent);
        }
        catch
        {
            return Activator.CreateInstance<T?>();
        }
    }

    protected async Task SendRequest(Uri url, Method method = Method.Get, object? body = null)
    {
        await SendRequestAndGetResponse(url, method, body);
    }

    protected async Task UpdateIfCacheIsOutdated(CancellationToken cToken = default)
    {
        if (!IsRequiredToForceUpdateCache()) return;

        await ConfiguringCacheTeachers(cToken).ConfigureAwait(false);
        await ConfiguringCacheCabs(cToken).ConfigureAwait(false);
        await ConfiguringCacheGroups(cToken).ConfigureAwait(false);
    }

    private async Task ConfiguringCacheGroups(CancellationToken cToken = default)
    {
        var resultApiGroups = await SendRequest<IList<SamGkGroupApiResult>>(new Uri("https://mfc.samgk.ru/api/groups"), cToken: cToken).ConfigureAwait(false);

        if (resultApiGroups == null || !resultApiGroups.Any()) return;

        GroupsCache = new List<LifeTimeMemory<IResultOutGroup>>();
        
        var items = resultApiGroups
            .Select(IResultOutGroup (x) => new ResultOutGroup
            {
                Id = x.Id,
                Name = x.Name,
                Currator = ExtractIdentityFromCache(x.Currator),
            })
            .OrderBy(x => x.Name)
            .Where(x => x.Course <= 5)
            .ToList();
        
        foreach (var item in items) SaveToCache(item, DefaultLifeTimeInMinutesForCommon);
    }

    private async Task ConfiguringCacheTeachers(CancellationToken cToken = default)
    {
        var resultApiTeachers = await SendRequest<IList<SamgkTeacherApiResult>>(new Uri("https://mfc.samgk.ru/api/teachers"), cToken: cToken).ConfigureAwait(false);

        if (resultApiTeachers == null || !resultApiTeachers.Any()) return;

        IdentityCache = new List<LifeTimeMemory<IResultOutIdentity>>();
        
        var items = resultApiTeachers
            .Select(IResultOutIdentity (x) => new ResultOutIdentity
                        {
                            Id = Convert.ToInt64(x.Id),
                            Name = x.Name
                        })
                        .OrderBy(x => x.Name)
                        .ToList();
        
        foreach (var item in items) SaveToCache(item, DefaultLifeTimeInMinutesForCommon);
    }

    private async Task ConfiguringCacheCabs(CancellationToken cToken = default)
    {
        var resultApiCabs = await SendRequest<Dictionary<string, string>>(new Uri("https://mfc.samgk.ru/api/cabs"), cToken: cToken).ConfigureAwait(false);

        if (resultApiCabs == null || !resultApiCabs.Any()) return;

        CabsCache = new List<LifeTimeMemory<IResultOutCab>>();

        var items = resultApiCabs
            .Select(IResultOutCab (x) => new ResultOutCab
            {
                Adress = x.Value
            })
            .OrderBy(x => x.Adress)
            .ToList();
        
        foreach (var item in items) SaveToCache(item, DefaultLifeTimeInMinutesForCommon);
    }
}