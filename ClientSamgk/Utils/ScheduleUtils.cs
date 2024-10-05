using ClientSamgkApiModelResponse.Shedules;

namespace ClientSamgk.Utils;

public static class ScheduleUtils
{
    public static DateTime GetStartLessonTime(this ScheduleItem scheduleItem, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday && date.Month != 6 && date.Month != 7)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day, 08, 25, 00),
                1 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day, 09, 15, 00),
                1 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day, 09, 15, 00),
                1 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day, 10, 10, 00),
                2 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day, 11, 00, 00),
                2 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day, 11, 00, 00),
                2 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day, 12, 15, 00),
                3 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day, 13, 05, 00),
                3 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day, 13, 05, 00),
                3 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,14, 00, 00),
                4 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,14, 50, 00),
                4 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,14, 50, 00),
                4 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,15, 45, 00),
                5 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,16, 35, 00),
                5 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,16, 35, 00),
                5 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,17, 30, 00),
                6 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,18, 20, 00),
                6 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,18, 20, 00),
                6 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,19, 15, 00),
                _ => date
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,08, 25, 00),
            1 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,08, 25, 00),
            1 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,09, 15, 00),
            2 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,10, 10, 00),
            2 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,10, 10, 00),
            2 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,11, 00, 00),
            3 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,12, 15, 00),
            3 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,12, 15, 00),
            3 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,13, 05, 00),
            4 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,14, 00, 00),
            4 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,14, 00, 00),
            4 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,14, 50, 00),
            5 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,15, 45, 00),
            5 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,15, 45, 00),
            5 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,16, 35, 00),
            6 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,17, 30, 00),
            6 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,17, 30, 00),
            6 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,18, 20, 00),
            7 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,19, 15, 00),
            7 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,19, 15, 00),
            7 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,20, 05, 00), // ошибка???
            _ => date
        };
    }

    public static DateTime GetEndLessonTime(this ScheduleItem scheduleItem, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday && date.Month != 06 && date.Month != 07)
        {
            return scheduleItem.Pair switch
            {
                0 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,09, 10, 00),
                1 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,10, 55, 00),
                1 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,10, 00, 00),
                1 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,10, 55, 00),
                2 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,13, 00, 00),
                2 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,11, 45, 00),
                2 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,13, 00, 00),
                3 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,14, 45, 00),
                3 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,13, 50, 00),
                3 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,14, 45, 00),
                4 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,16, 30, 00),
                4 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,15, 35, 00),
                4 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,16, 30, 00),
                5 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,18, 15, 00),
                5 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,17, 20, 00),
                5 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,18, 15, 00),
                6 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,20, 00, 00),
                6 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,19, 05, 00),
                6 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,20, 00, 00),
                _ => date
            };
        }

        // Общие случаи для других дней
        return scheduleItem.Pair switch
        {
            1 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,10, 00, 00),
            1 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,09, 10, 00),
            1 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,10, 00, 00),
            2 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,11, 45, 00),
            2 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,10, 55, 00),
            2 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,11, 45, 00),
            3 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,13, 50, 00),
            3 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,13, 00, 00),
            3 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,13, 50, 00),
            4 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,15, 35, 00),
            4 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,14, 45, 00),
            4 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,15, 35, 00),
            5 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,17, 20, 00),
            5 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,16, 30, 00),
            5 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,17, 20, 00),
            6 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,19, 05, 00),
            6 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,18, 15, 00),
            6 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,19, 05, 00),
            7 when scheduleItem.Number == 0 => new DateTime(date.Year, date.Month, date.Day,20, 50, 00),
            7 when scheduleItem.Number == 1 => new DateTime(date.Year, date.Month, date.Day,20, 00, 00),
            7 when scheduleItem.Number == 2 => new DateTime(date.Year, date.Month, date.Day,20, 50, 00),
            _ => date
        };
    }
}