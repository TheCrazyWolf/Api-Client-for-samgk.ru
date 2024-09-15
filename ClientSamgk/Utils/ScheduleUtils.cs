using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Utils;

public static class ScheduleUtils
{
    public static TimeOnly GetStartLessonTime(this ScheduleItem scheduleItem, DateOnly date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday && date.Month != 06 && date.Month != 07)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new TimeOnly(08, 25),
                1 when scheduleItem.Number == 0 => new TimeOnly(09, 15),
                1 when scheduleItem.Number == 1 => new TimeOnly(09, 15),
                1 when scheduleItem.Number == 2 => new TimeOnly(10, 10),
                2 when scheduleItem.Number == 0 => new TimeOnly(11, 00),
                2 when scheduleItem.Number == 1 => new TimeOnly(11, 00),
                2 when scheduleItem.Number == 2 => new TimeOnly(12, 15),
                3 when scheduleItem.Number == 0 => new TimeOnly(13, 05),
                3 when scheduleItem.Number == 1 => new TimeOnly(13, 05),
                3 when scheduleItem.Number == 2 => new TimeOnly(14, 00),
                4 when scheduleItem.Number == 0 => new TimeOnly(14, 50),
                4 when scheduleItem.Number == 1 => new TimeOnly(14, 50),
                4 when scheduleItem.Number == 2 => new TimeOnly(15, 45),
                5 when scheduleItem.Number == 0 => new TimeOnly(16, 35),
                5 when scheduleItem.Number == 1 => new TimeOnly(16, 35),
                5 when scheduleItem.Number == 2 => new TimeOnly(17, 30),
                6 when scheduleItem.Number == 0 => new TimeOnly(18, 20),
                6 when scheduleItem.Number == 1 => new TimeOnly(18, 20),
                6 when scheduleItem.Number == 2 => new TimeOnly(19, 15),
                _ => TimeOnly.MinValue
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new TimeOnly(08, 25),
            1 when scheduleItem.Number == 1 => new TimeOnly(08, 25),
            1 when scheduleItem.Number == 2 => new TimeOnly(09, 15),
            2 when scheduleItem.Number == 0 => new TimeOnly(10, 10),
            2 when scheduleItem.Number == 1 => new TimeOnly(10, 10),
            2 when scheduleItem.Number == 2 => new TimeOnly(11, 00),
            3 when scheduleItem.Number == 0 => new TimeOnly(12, 15),
            3 when scheduleItem.Number == 1 => new TimeOnly(12, 15),
            3 when scheduleItem.Number == 2 => new TimeOnly(13, 05),
            4 when scheduleItem.Number == 0 => new TimeOnly(14, 00),
            4 when scheduleItem.Number == 1 => new TimeOnly(14, 00),
            4 when scheduleItem.Number == 2 => new TimeOnly(14, 50),
            5 when scheduleItem.Number == 0 => new TimeOnly(15, 45),
            5 when scheduleItem.Number == 1 => new TimeOnly(15, 45),
            5 when scheduleItem.Number == 2 => new TimeOnly(16, 35),
            6 when scheduleItem.Number == 0 => new TimeOnly(17, 30),
            6 when scheduleItem.Number == 1 => new TimeOnly(17, 30),
            6 when scheduleItem.Number == 2 => new TimeOnly(18, 20),
            7 when scheduleItem.Number == 0 => new TimeOnly(19, 15),
            7 when scheduleItem.Number == 1 => new TimeOnly(19, 15),
            7 when scheduleItem.Number == 2 => new TimeOnly(20, 05), // ошибка???
            _ => TimeOnly.MinValue
        };
    }

    public static TimeOnly GetEndLessonTime(this ScheduleItem scheduleItem, DateOnly date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday && date.Month != 06 && date.Month != 07)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new TimeOnly(09, 10),
                1 when scheduleItem.Number == 0 => new TimeOnly(10, 55),
                1 when scheduleItem.Number == 1 => new TimeOnly(10, 00),
                1 when scheduleItem.Number == 2 => new TimeOnly(10, 55),
                2 when scheduleItem.Number == 0 => new TimeOnly(13, 00),
                2 when scheduleItem.Number == 1 => new TimeOnly(11, 45),
                2 when scheduleItem.Number == 2 => new TimeOnly(13, 00),
                3 when scheduleItem.Number == 0 => new TimeOnly(14, 45),
                3 when scheduleItem.Number == 1 => new TimeOnly(13, 50),
                3 when scheduleItem.Number == 2 => new TimeOnly(14, 45),
                4 when scheduleItem.Number == 0 => new TimeOnly(16, 30),
                4 when scheduleItem.Number == 1 => new TimeOnly(15, 35),
                4 when scheduleItem.Number == 2 => new TimeOnly(16, 30),
                5 when scheduleItem.Number == 0 => new TimeOnly(18, 15),
                5 when scheduleItem.Number == 1 => new TimeOnly(17, 20),
                5 when scheduleItem.Number == 2 => new TimeOnly(18, 15),
                6 when scheduleItem.Number == 0 => new TimeOnly(20, 00),
                6 when scheduleItem.Number == 1 => new TimeOnly(19, 05),
                6 when scheduleItem.Number == 2 => new TimeOnly(20, 00),
                _ => TimeOnly.MaxValue
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new TimeOnly(10, 00),
            1 when scheduleItem.Number == 1 => new TimeOnly(09, 10),
            1 when scheduleItem.Number == 2 => new TimeOnly(10, 00),
            2 when scheduleItem.Number == 0 => new TimeOnly(11, 45),
            2 when scheduleItem.Number == 1 => new TimeOnly(10, 55),
            2 when scheduleItem.Number == 2 => new TimeOnly(11, 45),
            3 when scheduleItem.Number == 0 => new TimeOnly(13, 50),
            3 when scheduleItem.Number == 1 => new TimeOnly(13, 00),
            3 when scheduleItem.Number == 2 => new TimeOnly(13, 50),
            4 when scheduleItem.Number == 0 => new TimeOnly(15, 35),
            4 when scheduleItem.Number == 1 => new TimeOnly(14, 45),
            4 when scheduleItem.Number == 2 => new TimeOnly(15, 35),
            5 when scheduleItem.Number == 0 => new TimeOnly(17, 20),
            5 when scheduleItem.Number == 1 => new TimeOnly(16, 30),
            5 when scheduleItem.Number == 2 => new TimeOnly(17, 20),
            6 when scheduleItem.Number == 0 => new TimeOnly(19, 05),
            6 when scheduleItem.Number == 1 => new TimeOnly(18, 15),
            6 when scheduleItem.Number == 2 => new TimeOnly(19, 05),
            7 when scheduleItem.Number == 0 => new TimeOnly(20, 50),
            7 when scheduleItem.Number == 1 => new TimeOnly(20, 00),
            7 when scheduleItem.Number == 2 => new TimeOnly(20, 50),
            _ => TimeOnly.MaxValue
        };
    }
}