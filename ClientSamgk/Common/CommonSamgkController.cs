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
    protected readonly RestClient Client;

    protected CommonSamgkController()
    {
        Client = new RestClient();
        _ = ConfiguringCache();
    }

    protected async Task<T> SendRequest<T>(string url)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        var restResponse = await Client.ExecuteAsync(options);

        if (!restResponse.IsSuccessStatusCode || restResponse.Content == null)
            throw new UnsuccessResponse("");

        var deserializeObject = JsonConvert.DeserializeObject<T>(restResponse.Content);

        return deserializeObject ?? throw new DeserializationObjectNull(nameof(T));
    }

    private async Task ConfiguringCache()
    {
        await ConfiguringCacheGroups();
        await ConfiguringCacheTeachers();
        await ConfiguringCacheCabs();
    }

    private async Task ConfiguringCacheGroups()
    {
        CachesGroups = (await SendRequest<IList<SamGkGroupApiResult>>("https://mfc.samgk.ru/api/groups"))
            .Select(x => (IResultOutGroup)new ResultOutGroup
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }
    
    private async Task ConfiguringCacheTeachers()
    {
        CachedIdentities = (await SendRequest<IList<SamgkTeacherApiResult>>("https://mfc.samgk.ru/api/teachers"))
            .Select(x => (IResultOutIdentity)new ResultOutIdentity
            {
                Id = Convert.ToInt64(x.Id),
                Name = x.Name
            })
            .ToList();
    }
    
    private async Task ConfiguringCacheCabs()
    {
        CachesCabs = (await SendRequest<Dictionary<string,string>>("https://mfc.samgk.ru/api/cabs"))
            .Select(x => (IResultOutCab)new ResultOutCab
            {
                Adress = x.Value
            })
            .ToList();
    }
}