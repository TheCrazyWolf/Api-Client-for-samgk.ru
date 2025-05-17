using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Models.Params.Implementations.Cache;

public sealed class CacheOptions : ICacheOptions
{
    public CacheOptions()
    {
    }

    public CacheOptions(int lifeTimeObjectsForCommon, int
        lifeTimeObjectsForLong, int lifeTimeObjectsForShort)
    {
        LifeTimeObjectsForCommon = lifeTimeObjectsForCommon;
        LifeTimeObjectsForLong = lifeTimeObjectsForLong;
        LifeTimeObjectsForShort = lifeTimeObjectsForShort;
    }

    public int LifeTimeObjectsForCommon { get; set; } = 2880;
    public int LifeTimeObjectsForLong { get; set; } = 43200;
    public int LifeTimeObjectsForShort { get; set; } = 10;
}