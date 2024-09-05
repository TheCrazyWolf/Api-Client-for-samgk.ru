using ClientSamgk.Controllers;
using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Models.Account;

namespace SamGK_Api.Controllers;

public class AccountController : BaseController, IAccountController
{
    private IList<IEmployee>? _cachedEmployees;
    
    public IAccount? Authorization(ICredentialSgk packet)
    {
        return AuthorizationAsync(packet).GetAwaiter().GetResult();
    }

    public async Task<IAccount?> AuthorizationAsync(ICredentialSgk packet)
    {
        var options = new RestRequest("https://mfc.samgk.ru/api/auth", Method.Post);
        options.AddHeaders(GetHeaders());
        options.AddParameter("username", packet.Username);
        options.AddParameter("password", packet.Password);
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        return JsonConvert.DeserializeObject<Account>(result.Content);
    }

    public IList<IEmployee> GetEmployees(bool useLegacyMethod = false, bool forceLoad = false)
    {
        return GetEmployeesAsync(useLegacyMethod: useLegacyMethod, forceLoad: forceLoad).GetAwaiter().GetResult();
    }

    public async Task<IList<IEmployee>> GetEmployeesAsync(bool useLegacyMethod = false, bool forceLoad = false)
    {
        if (_cachedEmployees != null && !forceLoad)
            return _cachedEmployees ?? new List<IEmployee>();
        
        var options = new RestRequest(useLegacyMethod ? "https://asu.samgk.ru/api/teachers" : "https://mfc.samgk.ru/api/teachers");
        options.AddHeaders(GetHeaders());
        
        var result = await Client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return new List<IEmployee>();

        _cachedEmployees = JsonConvert.DeserializeObject<IList<Employee>>(result.Content)?.Cast<IEmployee>().ToList();
        return _cachedEmployees ?? new List<IEmployee>();
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