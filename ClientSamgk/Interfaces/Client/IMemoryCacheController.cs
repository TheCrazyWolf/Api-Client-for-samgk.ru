using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface IMemoryCacheController
{
    /// <summary>
    /// Очистка кеша если данные устарели.
    /// </summary>
    Task ClearIfOutDateAsync();

    /// <summary>
    /// Очистка кеша если устарели
    /// </summary>
    void ClearIfOutDate();

    /// <summary>
    /// Принудительная очитка кэша.
    /// </summary>
    void Clear();
}