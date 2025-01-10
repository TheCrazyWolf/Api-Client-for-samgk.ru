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

    public int LifeTimeCommonObjects { get; }
    public int LifeTimeObjectsForLong { get; }
    public int LifeTimeObjectsForShort { get; }
}