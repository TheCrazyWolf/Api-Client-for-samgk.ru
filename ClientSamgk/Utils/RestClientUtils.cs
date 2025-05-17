using Newtonsoft.Json;
using RestSharp;

namespace ClientSamgk.Utils;

public static class RestClientUtils
{
    public static async Task<RestResponse?> SendRequestAndGetResponse(
        this IRestClient client, Uri url,
        Method method = Method.Get,
        object? body = null, CancellationToken cToken = default)
    {
        var options = new RestRequest(url);
        options.ConfigureAntiGreedHeaders();
        if (body is not null && method is Method.Post or Method.Put) options.AddBody(body);
        return await client.ExecuteAsync(options, method, cToken).ConfigureAwait(false);
    }

    public static async Task<T?> SendRequest<T>(
        this IRestClient client, Uri url,
        Method method = Method.Get,
        object? body = null,
        CancellationToken cToken = default)
    {
        var restResponse = await client.SendRequestAndGetResponse(url, method, body, cToken).ConfigureAwait(false);
        if (restResponse is null || !restResponse.IsSuccessStatusCode || restResponse.Content == null) return default;
        return TryDeserializeObjectOrGetDefault<T>(restResponse.Content);
    }

    private static T? TryDeserializeObjectOrGetDefault<T>(string restResponseContent)
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
}