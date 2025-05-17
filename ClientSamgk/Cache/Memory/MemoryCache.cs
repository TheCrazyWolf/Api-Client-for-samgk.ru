using System.Diagnostics.CodeAnalysis;

namespace ClientSamgk.Cache.Memory;

/// <summary>
/// In memory cache store that manages objects with a specified lifetime
/// </summary>
/// <inheritdoc/>
public sealed class MemoryCache<T> : ICache<T> where T : class
{
    /// <inheritdoc/>
    public IReadOnlyList<LifeTimeMemory<T>> Data => _cache;
    private List<LifeTimeMemory<T>> _cache = [];

    /// <inheritdoc/>
    public bool TryExtractFromCache(Predicate<T> predicate, [MaybeNullWhen(false)] out T value)
    {
        var obj = ExtractFromCache(predicate);
        if (obj == null)
        {
            value = default;
            return false;
        }

        value = obj;
        return true;
    }

    /// <inheritdoc/>
    public T? ExtractFromCache(Predicate<T> predicate)
    {
        CleanupCache();
        return _cache.FirstOrDefault(x => predicate(x.Object))?.Object;
    }

    /// <inheritdoc/>
    public void SaveToCache(T item, int lifeTimeInMinutes)
    {
        var cacheItem = new LifeTimeMemory<T>
        {
            Object = item,
            DateTimeCanBeDeleted = DateTime.Now.AddMinutes(lifeTimeInMinutes),
            DateTimeAdded = DateTime.Now
        };
        _cache.Add(cacheItem);
    }

    /// <inheritdoc/>
    public void CleanupCache()
    {
        foreach (var item in _cache.Where(x => DateTime.Now >= x.DateTimeCanBeDeleted).ToList())
            _cache.Remove(item);
    }

    /// <inheritdoc/>
    public void DropCache()
    {
        _cache = [];
    }

    /// <inheritdoc/>
    public bool IsCacheOutdated() =>
        _cache.Any(x => x.DateTimeCanBeDeleted <= DateTime.Now) || _cache.Count == 0;
}