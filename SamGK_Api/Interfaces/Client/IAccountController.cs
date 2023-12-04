using SamGK_Api.Interfaces.Account;

namespace SamGK_Api.Interfaces.Client;

public interface IAccountController
{
    /// <summary>
    /// Авторизация с помощью учетных данных samgk.ru
    /// </summary>
    /// <param name="packet">Учетные данные - логин и пароль</param>
    /// <returns>В случае успешной авторизации возращается IAccount
    /// Если учетные данные оказались неверными - null
    /// </returns>
    IAccount? Authorization(ICredentialSgk packet);
    /// <summary>
    /// Авторизация с помощью учетных данных samgk.ru
    /// </summary>
    /// <param name="packet">Учетные данные - логин и пароль</param>
    /// <returns>В случае успешной авторизации возращается IAccount
    /// Если учетные данные оказались неверными - null
    /// </returns>
    Task<IAccount?> AuthorizationAsync(ICredentialSgk packet);

    /// <summary>
    /// Получение списка сотрудников колледжа
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;IEmployee&gt; если есть, что загружать, если нечего - null</returns>
    IEnumerable<IEmployee>? GetEmployees(bool forceLoad = false);
    /// <summary>
    /// Получение списка сотрудников колледжа
    /// При первой загрузке список помещается в статичный лист,
    /// при следующем обращении подтягиваются данные из листа
    /// </summary>
    /// <param name="forceLoad">Принудительная загрузка.
    /// Передайте true, если хотите заново загрузить список</param>
    /// <returns>Возращает IEnumerable&lt;IEmployee&gt; если есть, что загружать, если нечего - null</returns>
    Task<IEnumerable<IEmployee>?> GetEmployeesAsync(bool forceLoad = false);
}