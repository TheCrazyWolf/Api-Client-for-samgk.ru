using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ClientSamgkOutputResponse.Enums;

namespace ClientSamgk.Utils;

public static class EnumExtensions
{
    public static string GetDisplayName(this ScheduleSearchType value)
    {
        return value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName() ?? value.ToString();
    }
}