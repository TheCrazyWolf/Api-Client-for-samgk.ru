using ClientSamgk.Models.Params.Interfaces.Cache;

namespace ClientSamgk.Models.Params.Implementations.Cache;

public class CacheOptions : ICacheOptions
{
    public CacheOptions()
    {
        
    }

    public CacheOptions(int lifeTimeCommonObjects, int 
        lifeTimeObjectsForLong, int lifeTimeObjectsForShort)
    {
        LifeTimeCommonObjectsObjects = lifeTimeCommonObjects;
        LifeTimeObjectsForLong = lifeTimeObjectsForLong;
        LifeTimeObjectsForShort = lifeTimeObjectsForShort;
    }

    public int LifeTimeCommonObjectsObjects { get; set; } = 2880;
    public int LifeTimeObjectsForLong { get; set; } = 43200;
    public int LifeTimeObjectsForShort { get; set; } = 10;
}