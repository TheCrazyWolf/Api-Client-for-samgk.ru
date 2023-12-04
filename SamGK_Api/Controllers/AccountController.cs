using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Models.Account;

namespace SamGK_Api.Controllers;

public class AccountController : _BaseController, IAccountController
{
    private IEnumerable<IEmployee>? _cachedEmployees;
    
    public IAccount? Authorization(ICredentialSgk packet)
    {
        var options = new RestRequest("https://mfc.samgk.ru/api/auth", Method.Post);
        
        options.AddHeaders(GetHeaders());
        options.AddParameter("username", packet.Username);
        options.AddParameter("password", packet.Password);

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        return JsonConvert.DeserializeObject<Account>(result.Content);
    }

    public async Task<IAccount?> AuthorizationAsync(ICredentialSgk packet)
    {
        var options = new RestRequest("https://mfc.samgk.ru/api/auth", Method.Post);
        options.AddHeaders(GetHeaders());
        options.AddParameter("username", packet.Username);
        options.AddParameter("password", packet.Password);
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        return JsonConvert.DeserializeObject<Account>(result.Content);
    }

    public IEnumerable<IEmployee>? GetEmployees(bool forceLoad = false)
    {
        if (_cachedEmployees != null && !forceLoad)
            return _cachedEmployees;
        
        var options = new RestRequest("https://asu.samgk.ru/api/teachers", Method.Get);
        options.AddHeaders(GetHeaders());
        
        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedEmployees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result.Content);
        return _cachedEmployees;
    }

    public async Task<IEnumerable<IEmployee>?> GetEmployeesAsync(bool forceLoad = false)
    {
        if (_cachedEmployees != null && !forceLoad)
            return _cachedEmployees;
        
        var options = new RestRequest("https://asu.samgk.ru/api/teachers", Method.Get);
        options.AddHeaders(GetHeaders());
        
        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        _cachedEmployees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result.Content);
        return _cachedEmployees;
    }

    public IEmployee? GetEmployee(int idEmployee)
    {
        _cachedEmployees ??= GetEmployees();
        return _cachedEmployees?.FirstOrDefault(employee => employee.Id == idEmployee);
    }

    public IEmployee? GetEmployee(string nameSearch)
    {
        _cachedEmployees ??= GetEmployees();
        return _cachedEmployees?.FirstOrDefault(employee => employee.Name.ToUpper() == nameSearch.ToUpper());
    }
}