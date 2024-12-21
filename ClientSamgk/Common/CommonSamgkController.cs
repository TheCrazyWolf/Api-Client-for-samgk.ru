using ClientSamgk.Utils;
using ClientSamgkApiModelResponse.Groups;
using ClientSamgkApiModelResponse.Teachers;
using ClientSamgkOutputResponse.Implementation.Cabs;
using ClientSamgkOutputResponse.Implementation.Groups;
using ClientSamgkOutputResponse.Implementation.Identity;
using ClientSamgkOutputResponse.Interfaces.Groups;
using Newtonsoft.Json;
using RestSharp;

namespace ClientSamgk.Common;

public class CommonSamgkController : CommonCache
{
    private readonly RestClient _client = new(new HttpClient());
    const string _urlApiSgk = "https://mfc.samgk.ru/api/";

    async Task<RestResponse?> ExecuteRequest(string url, Method method = Method.Get, object? body = null)
    {
        var request = new RestRequest(url);
        request.ConfigureAntiGreedHeaders();

        if (body is not null && (method is (Method.Post or Method.Put)))
        {
            request.AddBody(body);
        }

        return await _client.ExecuteAsync(request, method).ConfigureAwait(false);
    }

    protected async Task<T?> SendRequest<T>(string url, Method method = Method.Get, object? body = null)
    {
        var restResponse = await ExecuteRequest(url, method, body).ConfigureAwait(false);

        if (restResponse?.IsSuccessStatusCode is not true || string.IsNullOrEmpty(restResponse?.Content))
        {
            return default;
        }

        return TryDeserializeSafe<T>(restResponse.Content);
    }

    //protected async Task SendRequest(string url, Method method = Method.Get, object? body = null) // ����� �� ������������
    //{
    //    await ExecuteRequest(url, method, body);
    //}

    protected async Task UpdateIfCacheIsOutdated()
    {
        if (!ForceUpdateCache)
        {
            return;
        }

        await configuringCacheTeachers().ConfigureAwait(false);
        await configuringCacheCabs().ConfigureAwait(false);
        await configuringCacheGroups().ConfigureAwait(false);
    }

    T? TryDeserializeSafe<T>(string restResponseContent)
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

    async Task configuringCacheGroups()
    {
        var resultApiGroups = await SendRequest<IList<SamGkGroupApiResult>>($"{_urlApiSgk}groups").ConfigureAwait(false);

        if (resultApiGroups == null || !resultApiGroups.Any())
        {
            return;
        }

        GroupsCache = [];

        var items = resultApiGroups
            .Select(IResultOutGroup (x) => new ResultOutGroup
            {
                Id = x.Id,
                Name = x.Name,
                Currator = ExtractFromIdentityCache(x.Currator),
            })
            .OrderBy(x => x.Name)
            .Where(x => x.Course <= 5)
            .ToList();

        foreach (var item in items)
        {
            SaveToCache(item, DefaultLifeTimeInMinutesForCommon);
        }
    }

    async Task configuringCacheTeachers()
    {
        var resultApiTeachers = await SendRequest<IList<SamgkTeacherApiResult>>($"{_urlApiSgk}teachers").ConfigureAwait(false);

        if (resultApiTeachers == null || !resultApiTeachers.Any())
        {
            return;
        }

        IdentityCache = [];

        foreach (var teacher in resultApiTeachers.OrderBy(t => t.Name))
        {
            var resultOutIdentity = new ResultOutIdentity
            {
                Id = Convert.ToInt64(teacher.Id),
                Name = teacher.Name
            };

            SaveToCache(resultOutIdentity, DefaultLifeTimeInMinutesForCommon);
        }
    }

    async Task configuringCacheCabs()
    {
        var resultApiCabs = await SendRequest<Dictionary<string, string>>($"{_urlApiSgk}cabs").ConfigureAwait(false);

        if (resultApiCabs == null || !resultApiCabs.Any())
        {
            return;
        }

        // ������� ���
        CabsCache = [];

        // ��������� ������ � ���, ������� ������� ��������
        foreach (var item in resultApiCabs.OrderBy(x => x.Value))
        {
            SaveToCache(new ResultOutCab { Adress = item.Value }, DefaultLifeTimeInMinutesForCommon);
        }
    }
}