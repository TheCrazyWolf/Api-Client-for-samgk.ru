namespace ClientSamgk.Models.Params.Interfaces.Cache;

public interface ICacheOptions
{
    int LifeTimeCommonObjects { get; }
    int LifeTimeObjectsForLong { get;  }
    int LifeTimeObjectsForShort { get;  }
}