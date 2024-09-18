﻿using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.LegacyImplementation;

namespace ClientSamgk.Utils;

public static class ScheduleUtils
{
    public static TimeOnlyLegacy GetStartLessonTime(this ScheduleItem scheduleItem, DateOnlyLegacy date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday && date.Month != 6 && date.Month != 7)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new TimeOnlyLegacy(08, 25),
                1 when scheduleItem.Number == 0 => new TimeOnlyLegacy(09, 15),
                1 when scheduleItem.Number == 1 => new TimeOnlyLegacy(09, 15),
                1 when scheduleItem.Number == 2 => new TimeOnlyLegacy(10, 10),
                2 when scheduleItem.Number == 0 => new TimeOnlyLegacy(11, 00),
                2 when scheduleItem.Number == 1 => new TimeOnlyLegacy(11, 00),
                2 when scheduleItem.Number == 2 => new TimeOnlyLegacy(12, 15),
                3 when scheduleItem.Number == 0 => new TimeOnlyLegacy(13, 05),
                3 when scheduleItem.Number == 1 => new TimeOnlyLegacy(13, 05),
                3 when scheduleItem.Number == 2 => new TimeOnlyLegacy(14, 00),
                4 when scheduleItem.Number == 0 => new TimeOnlyLegacy(14, 50),
                4 when scheduleItem.Number == 1 => new TimeOnlyLegacy(14, 50),
                4 when scheduleItem.Number == 2 => new TimeOnlyLegacy(15, 45),
                5 when scheduleItem.Number == 0 => new TimeOnlyLegacy(16, 35),
                5 when scheduleItem.Number == 1 => new TimeOnlyLegacy(16, 35),
                5 when scheduleItem.Number == 2 => new TimeOnlyLegacy(17, 30),
                6 when scheduleItem.Number == 0 => new TimeOnlyLegacy(18, 20),
                6 when scheduleItem.Number == 1 => new TimeOnlyLegacy(18, 20),
                6 when scheduleItem.Number == 2 => new TimeOnlyLegacy(19, 15),
                _ => new TimeOnlyLegacy()
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new TimeOnlyLegacy(08, 25),
            1 when scheduleItem.Number == 1 => new TimeOnlyLegacy(08, 25),
            1 when scheduleItem.Number == 2 => new TimeOnlyLegacy(09, 15),
            2 when scheduleItem.Number == 0 => new TimeOnlyLegacy(10, 10),
            2 when scheduleItem.Number == 1 => new TimeOnlyLegacy(10, 10),
            2 when scheduleItem.Number == 2 => new TimeOnlyLegacy(11, 00),
            3 when scheduleItem.Number == 0 => new TimeOnlyLegacy(12, 15),
            3 when scheduleItem.Number == 1 => new TimeOnlyLegacy(12, 15),
            3 when scheduleItem.Number == 2 => new TimeOnlyLegacy(13, 05),
            4 when scheduleItem.Number == 0 => new TimeOnlyLegacy(14, 00),
            4 when scheduleItem.Number == 1 => new TimeOnlyLegacy(14, 00),
            4 when scheduleItem.Number == 2 => new TimeOnlyLegacy(14, 50),
            5 when scheduleItem.Number == 0 => new TimeOnlyLegacy(15, 45),
            5 when scheduleItem.Number == 1 => new TimeOnlyLegacy(15, 45),
            5 when scheduleItem.Number == 2 => new TimeOnlyLegacy(16, 35),
            6 when scheduleItem.Number == 0 => new TimeOnlyLegacy(17, 30),
            6 when scheduleItem.Number == 1 => new TimeOnlyLegacy(17, 30),
            6 when scheduleItem.Number == 2 => new TimeOnlyLegacy(18, 20),
            7 when scheduleItem.Number == 0 => new TimeOnlyLegacy(19, 15),
            7 when scheduleItem.Number == 1 => new TimeOnlyLegacy(19, 15),
            7 when scheduleItem.Number == 2 => new TimeOnlyLegacy(20, 05), // ошибка???
            _ => new TimeOnlyLegacy()
        };
    }

    public static TimeOnlyLegacy GetEndLessonTime(this ScheduleItem scheduleItem, DateOnlyLegacy date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday && date.Month != 06 && date.Month != 07)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new TimeOnlyLegacy(09, 10),
                1 when scheduleItem.Number == 0 => new TimeOnlyLegacy(10, 55),
                1 when scheduleItem.Number == 1 => new TimeOnlyLegacy(10, 00),
                1 when scheduleItem.Number == 2 => new TimeOnlyLegacy(10, 55),
                2 when scheduleItem.Number == 0 => new TimeOnlyLegacy(13, 00),
                2 when scheduleItem.Number == 1 => new TimeOnlyLegacy(11, 45),
                2 when scheduleItem.Number == 2 => new TimeOnlyLegacy(13, 00),
                3 when scheduleItem.Number == 0 => new TimeOnlyLegacy(14, 45),
                3 when scheduleItem.Number == 1 => new TimeOnlyLegacy(13, 50),
                3 when scheduleItem.Number == 2 => new TimeOnlyLegacy(14, 45),
                4 when scheduleItem.Number == 0 => new TimeOnlyLegacy(16, 30),
                4 when scheduleItem.Number == 1 => new TimeOnlyLegacy(15, 35),
                4 when scheduleItem.Number == 2 => new TimeOnlyLegacy(16, 30),
                5 when scheduleItem.Number == 0 => new TimeOnlyLegacy(18, 15),
                5 when scheduleItem.Number == 1 => new TimeOnlyLegacy(17, 20),
                5 when scheduleItem.Number == 2 => new TimeOnlyLegacy(18, 15),
                6 when scheduleItem.Number == 0 => new TimeOnlyLegacy(20, 00),
                6 when scheduleItem.Number == 1 => new TimeOnlyLegacy(19, 05),
                6 when scheduleItem.Number == 2 => new TimeOnlyLegacy(20, 00),
                _ => new TimeOnlyLegacy()
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new TimeOnlyLegacy(10, 00),
            1 when scheduleItem.Number == 1 => new TimeOnlyLegacy(09, 10),
            1 when scheduleItem.Number == 2 => new TimeOnlyLegacy(10, 00),
            2 when scheduleItem.Number == 0 => new TimeOnlyLegacy(11, 45),
            2 when scheduleItem.Number == 1 => new TimeOnlyLegacy(10, 55),
            2 when scheduleItem.Number == 2 => new TimeOnlyLegacy(11, 45),
            3 when scheduleItem.Number == 0 => new TimeOnlyLegacy(13, 50),
            3 when scheduleItem.Number == 1 => new TimeOnlyLegacy(13, 00),
            3 when scheduleItem.Number == 2 => new TimeOnlyLegacy(13, 50),
            4 when scheduleItem.Number == 0 => new TimeOnlyLegacy(15, 35),
            4 when scheduleItem.Number == 1 => new TimeOnlyLegacy(14, 45),
            4 when scheduleItem.Number == 2 => new TimeOnlyLegacy(15, 35),
            5 when scheduleItem.Number == 0 => new TimeOnlyLegacy(17, 20),
            5 when scheduleItem.Number == 1 => new TimeOnlyLegacy(16, 30),
            5 when scheduleItem.Number == 2 => new TimeOnlyLegacy(17, 20),
            6 when scheduleItem.Number == 0 => new TimeOnlyLegacy(19, 05),
            6 when scheduleItem.Number == 1 => new TimeOnlyLegacy(18, 15),
            6 when scheduleItem.Number == 2 => new TimeOnlyLegacy(19, 05),
            7 when scheduleItem.Number == 0 => new TimeOnlyLegacy(20, 50),
            7 when scheduleItem.Number == 1 => new TimeOnlyLegacy(20, 00),
            7 when scheduleItem.Number == 2 => new TimeOnlyLegacy(20, 50),
            _ => new TimeOnlyLegacy()
        };
    }
}