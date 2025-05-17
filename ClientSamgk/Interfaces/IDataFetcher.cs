namespace ClientSamgk.Interfaces;

public interface IDataFetcher<T> where T : class
{
    Task<IEnumerable<T>> FetchAsync(CancellationToken cToken = default);
}