using System.Text;
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
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ClientSamgk.Common;

public class CommonSamgkController : CommonCache
{
    private readonly HttpClient _client = new();

    private async Task<HttpResponseMessage?> SendRequestAndGetResponse(string url, HttpMethod method,
        object? body = null)
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(url),
            Method = method
        };
        
        if (body != null)
        {
            var json = JsonSerializer.Serialize(body); request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        foreach (var header in HeadersUtils.GetHeaders())
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        try
        {
            return await _client.SendAsync(request);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.Message);   
#endif
            return default;
        }
    }


    protected async Task<T?> SendRequest<T>(string url, HttpMethod method, object? body = null)
    {
        var restResponse = await SendRequestAndGetResponse(url, method, body);
        if (restResponse is null || !restResponse.IsSuccessStatusCode) return default;
        return TryDeserializeObjectOrGetDefault<T>(await restResponse.Content.ReadAsStringAsync());
    }

    private T? TryDeserializeObjectOrGetDefault<T>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch(Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.Message);   
#endif
            return default;
        }
    }
    
    protected async Task SendRequest(string url, HttpMethod method, object? body = null)
    {
        await SendRequestAndGetResponse(url, method, body);
    }

    protected async Task UpdateIfCacheIsOutdated()
    {
        if (!IsRequiredToForceUpdateCache()) return;

        await ConfiguringCacheTeachers();
        await ConfiguringCacheCabs();
        await ConfiguringCacheGroups();
    }

    private async Task ConfiguringCacheGroups()
    {
        var resultApiGroups = await SendRequest<IList<SamGkGroupApiResult>>("https://mfc.samgk.ru/api/groups", HttpMethod.Get);

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

    private async Task ConfiguringCacheTeachers()
    {
        var resultApiTeachers = await SendRequest<IList<SamgkTeacherApiResult>>("https://mfc.samgk.ru/api/teachers", HttpMethod.Get);

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

    private async Task ConfiguringCacheCabs()
    {
        var resultApiCabs = await SendRequest<Dictionary<string, string>>("https://mfc.samgk.ru/api/cabs", HttpMethod.Get);

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