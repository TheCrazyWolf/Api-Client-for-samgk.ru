using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Interfaces.Client;

public interface IMemoryCacheController
{
    /// <summary>
    /// Очистка кеша если данные устарели
    /// </summary>
    Task ClearIfOutDateAsync();
    void ClearIfOutDate();
    
    /// <summary>
    /// Принудительная очитка кеша
    /// </summary>
    void Clear();

    /// <summary>
    /// Установка параметров для кеша
    /// </summary>
    /// <param name="options">Модель настроек, реализующих интерфейс ICacheOptions</param>
    void SetLifeTime(ICacheOptions options);
}