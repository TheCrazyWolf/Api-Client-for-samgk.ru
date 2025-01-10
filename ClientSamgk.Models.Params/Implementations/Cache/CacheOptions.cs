using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Models.Params.Implementations.Cache;

public class CacheOptions : ICacheOptions
{
    public CacheOptions()
    {
        
    }

    public CacheOptions(int lifeTimeInMinutesForCommon, int 
        lifeTimeInMinutesLong, int lifeTimeInMinutesShort)
    {
        LifeTimeCommonObjects = lifeTimeInMinutesForCommon;
        LifeTimeObjectsForLong = lifeTimeInMinutesLong;
        LifeTimeObjectsForShort = lifeTimeInMinutesShort;
    }

    public int LifeTimeCommonObjects { get; } = 2880;
    public int LifeTimeObjectsForLong { get; } = 43200;
    public int LifeTimeObjectsForShort { get; } = 10;
}