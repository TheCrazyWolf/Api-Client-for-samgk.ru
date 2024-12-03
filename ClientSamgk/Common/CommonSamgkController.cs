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
    private DateTime _lastUpdate;
    private readonly RestClient _client = new ();

    private async Task<RestResponse?> SendRequestAndGetResponse(string url, Method method = Method.Get, object? body = null)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        if (body is not null && method is Method.Post or Method.Put) options.AddBody(body);
        return await _client.ExecuteAsync(options, method);
    }
    
    
    protected async Task<T?> SendRequest<T>(string url, Method method = Method.Get, object? body = null)
    {
        var restResponse = await SendRequestAndGetResponse(url, method, body);
        if (restResponse is null || !restResponse.IsSuccessStatusCode || restResponse.Content == null) return default;
        return TryDeserializeObject<T>(restResponse.Content);
    }

    private T? TryDeserializeObject<T>(string restResponseContent)
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

    protected async Task SendRequest(string url, Method method = Method.Get, object? body = null)
    {
        await SendRequestAndGetResponse(url, method, body);
    }
    
    protected async Task UpdateIfCacheIsOutdated()
    {
        if (!IsRequiredToForceUpdateCache()) return;

        _lastUpdate = DateTime.Now;
        await ConfiguringCacheTeachers();
        await ConfiguringCacheCabs();
        await ConfiguringCacheGroups();
    }

    private async Task ConfiguringCacheGroups()
    {
        var resultApiGroups = await SendRequest<IList<SamGkGroupApiResult>>("https://mfc.samgk.ru/api/groups");
        
        if(resultApiGroups == null) return;
        
        CachesGroups = resultApiGroups
            .Select(IResultOutGroup (x) => new ResultOutGroup
            {
                Id = x.Id,
                Name = x.Name,
                Currator = CachedIdentities.FirstOrDefault(y => y.Id == x.Currator),
            })
            .OrderBy(x=> x.Name)
            .Where(x=> x.Course <= 5)
            .ToList(); 
    }

    private async Task ConfiguringCacheTeachers()
    {
        var resultApiTeachers = await SendRequest<IList<SamgkTeacherApiResult>>("https://mfc.samgk.ru/api/teachers");

        if (resultApiTeachers == null) return;
        
        CachedIdentities = resultApiTeachers
            .Select(IResultOutIdentity (x) => new ResultOutIdentity
            {
                Id = Convert.ToInt64(x.Id),
                Name = x.Name
            })
            .OrderBy(x=> x.Name)
            .ToList();
    }

    private async Task ConfiguringCacheCabs()
    {
        var resultApiCabs = await SendRequest<Dictionary<string, string>>("https://mfc.samgk.ru/api/cabs");
        
        if (resultApiCabs == null) return;
        
        CachesCabs = resultApiCabs
            .Select(IResultOutCab (x) => new ResultOutCab
            {
                Adress = x.Value
            })
            .OrderBy(x=> x.Adress)
            .ToList();
    }

    private bool IsRequiredToForceUpdateCache()
    {
        if (CachesCabs.Count is 0 || CachesGroups.Count is 0 || CachedIdentities.Count is 0) return true;
        return (DateTime.Now - _lastUpdate).Days >= 3;
    }
}