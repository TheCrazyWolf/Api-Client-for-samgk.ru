﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ClientSamgk.Utils;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value) => value.GetType()
        .GetMember(value.ToString())
        .FirstOrDefault()?
        .GetCustomAttribute<DisplayAttribute>()?
        .GetName() ?? value.ToString();
}