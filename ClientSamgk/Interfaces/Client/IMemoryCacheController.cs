using ClientSamgkOutputResponse.Interfaces.Cabs;

namespace ClientSamgk.Interfaces.Client;

public interface IMemoryCacheController
{
    /// <summary>
    /// Очистка кеша если данные устарели.
    /// </summary>
    Task ClearIfOutDateAsync();
    void ClearIfOutDate();
    
    /// <summary>
    /// Принудительная очитка кеша.
    /// </summary>
    void Clear();
}