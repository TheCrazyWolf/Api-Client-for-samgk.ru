using RestSharp;

namespace SamGK_Api.Controllers;

public class _BaseController
{
    protected RestClient _client;

    public _BaseController()
    {
        _client = new();
    }
}