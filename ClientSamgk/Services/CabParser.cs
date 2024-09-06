using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Models.Cabs;

namespace SamGK_Api.Services;

public static class CabParser
{
    
    /* 
     * Одно приходит в виде JSON, другое в виде XML
     * А КАБИНЕТЫ ПРИХОДЯТ В ВИДЕ СЛОВАРИКА!! (Если можно так называть!!)
     * СЕРЕГА ЧТО ЗА ХЕРНЯ?????
     */
    
    public static IList<ICab>? Parse(Dictionary<string, string>? dataCabs)
    {
        var data = dataCabs?
            .Select(item => new Cab
                { Name = item.Value })
            .Cast<ICab>()
            .ToList();

        return data;
    } 
}