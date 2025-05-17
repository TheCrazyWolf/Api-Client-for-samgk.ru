using System.Diagnostics.CodeAnalysis;

namespace ClientSamgk.Cache;

/// <summary>
/// Defines the contract for a generic cache store that manages objects with a specified lifetime
/// </summary>
/// <typeparam name="T">The type of objects to be stored in the cache</typeparam>
public interface ICache<T> where T : class
{
    /// <summary>
    /// Gets the current data in the cache as a read-only list
    /// </summary>
    IReadOnlyList<LifeTimeMemory<T>> Data { get; }

    /// <summary>
    /// Try to gets the value from cache with the specified predicate
    /// </summary>
    /// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for</param>
    /// <param name="value">
    /// When this method returns, contains the first element that matches the conditions defined by the specified predicate, if found;
    /// otherwise, the default value for the type of the <c>value</c> parameter. This parameter is passed uninitialized
    /// </param>
    /// <returns><c>true</c> if cache contains an element with the specified predicate; otherwise, <c>false</c></returns>
    bool TryExtractFromCache(Predicate<T> predicate, [MaybeNullWhen(false)] out T value);

    /// <summary>
    /// Gets the value from cache with the specified predicate
    /// </summary>
    /// <param name="predicate">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for</param>
    /// <returns>
    /// The first element that matches the conditions defined by the specified predicate, if found; otherwise, <c>null</c>
    /// </returns>
    T? ExtractFromCache(Predicate<T> predicate);

    /// <summary>
    /// Store item into cache with specified lifetime
    /// </summary>
    /// <param name="item">item to store</param>
    /// <param name="lifeTimeInMinutes">lifetime of item in cache at minutes</param>
    void SaveToCache(T item, int lifeTimeInMinutes);

    /// <summary>
    /// Remove item from cache with lifetime is gone
    /// </summary>
    void CleanupCache();

    /// <summary>
    /// Remove all items from cache
    /// </summary>
    void DropCache();

    /// <summary>
    /// Return status if cache is outdated
    /// </summary>
    /// <returns><c>true</c> if cache contains items with gone lifetime, or cache is empty; otherwise <c>false</c></returns>
    bool IsCacheOutdated();
}