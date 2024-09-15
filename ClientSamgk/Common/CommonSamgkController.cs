using ClientSamgk.Exceptions;
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
    private DateTime _lastUpdate = default!;
    private readonly RestClient _client = new RestClient();

    protected async Task<T> SendRequest<T>(string url)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        var restResponse = await _client.ExecuteAsync(options);

        if (!restResponse.IsSuccessStatusCode || restResponse.Content == null)
            throw new UnsuccessResponse("Пустой ответ или сервер вернул неуспешный код");

        var deserializeObject = JsonConvert.DeserializeObject<T>(restResponse.Content);

        return deserializeObject ?? throw new DeserializationObjectNull($"Ошибка при десерализации {nameof(T)}");
    }

    protected async Task ConfiguringCache()
    {
        if (!IsRequiredToForceUpdateCache()) return;

        _lastUpdate = DateTime.Now;
        await ConfiguringCacheTeachers();
        await ConfiguringCacheCabs();
        await ConfiguringCacheGroups();
    }

    private async Task ConfiguringCacheGroups()
    {
        try
        {
            CachesGroups = (await SendRequest<IList<SamGkGroupApiResult>>("https://mfc.samgk.ru/api/groups"))
                .Select(x => (IResultOutGroup)new ResultOutGroup
                {
                    Id = x.Id,
                    Name = x.Name,
                    Currator = CachedIdentities.FirstOrDefault(y => y.Id == x.Currator),
                })
                .OrderBy(x=> x.Name)
                .ToList();
        }
        catch 
        {
            //
        }
    }

    private async Task ConfiguringCacheTeachers()
    {
        try
        {
            CachedIdentities = (await SendRequest<IList<SamgkTeacherApiResult>>("https://mfc.samgk.ru/api/teachers"))
                .Select(x => (IResultOutIdentity)new ResultOutIdentity
                {
                    Id = Convert.ToInt64(x.Id),
                    Name = x.Name
                })
                .OrderBy(x=> x.Name)
                .ToList();
        }
        catch 
        {
            // 
        }
    }

    private async Task ConfiguringCacheCabs()
    {
        try
        {
            CachesCabs = (await SendRequest<Dictionary<string, string>>("https://mfc.samgk.ru/api/cabs"))
                .Select(x => (IResultOutCab)new ResultOutCab
                {
                    Adress = x.Value
                })
                .OrderBy(x=> x.Adress)
                .ToList();
        }
        catch 
        {
            // 
        }
    }

    private bool IsRequiredToForceUpdateCache()
    {
        if (CachesCabs.Count is 0 || CachesGroups.Count is 0 || CachedIdentities.Count is 0)
            return true;

        if ((DateTime.Now - _lastUpdate).Days < 3)
            return false;

        return true;
    }
}