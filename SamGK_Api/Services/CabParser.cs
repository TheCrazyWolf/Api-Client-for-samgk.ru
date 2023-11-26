using System.Collections;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Models.Cabs;

namespace SamGK_Api.Services;

public static class CabParser
{
    public static IEnumerable<ICab>? Parse(Dictionary<string, string>? dataCabs)
    {
        var data = dataCabs?.Select(item => new Cab() { name = item.Value })
            .Cast<ICab>()
            .ToList();

        return data;
    } 
}