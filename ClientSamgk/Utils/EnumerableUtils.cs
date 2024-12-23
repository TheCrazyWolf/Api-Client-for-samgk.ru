namespace ClientSamgk.Utils;

public static class EnumerableUtils
{
    public static async Task<IEnumerable<TOut>> LoopAsyncResult<TIn, TOut>(this IEnumerable<TIn> list,
        Func<TIn, Task<TOut>> function)
    {
        var loopResult = await Task.WhenAll(list.Select(function));
        return loopResult.ToList().AsEnumerable();
    }
}