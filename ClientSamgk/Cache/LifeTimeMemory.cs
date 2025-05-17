namespace ClientSamgk.Cache;

public sealed class LifeTimeMemory<T>
{
    public DateTime DateTimeAdded { get; set; } = DateTime.Now;
    public DateTime DateTimeCanBeDeleted { get; set; }
    public T Object { get; set; } = default!;
}