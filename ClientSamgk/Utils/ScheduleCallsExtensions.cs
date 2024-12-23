﻿using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Implementation.Schedule;
namespace ClientSamgk.Utils;

public static class ScheduleCallsExtensions
{
    static readonly Dictionary<int, IList<DurationLessonDetails>> StandartSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("08:25"), TimeOnly.Parse("09:10")),
                new DurationLessonDetails(TimeOnly.Parse("09:15"), TimeOnly.Parse("10:00"))]
        },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("10:10"), TimeOnly.Parse("10:55")),
                new DurationLessonDetails(TimeOnly.Parse("11:00"), TimeOnly.Parse("11:45"))]
        },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("12:15"), TimeOnly.Parse("13:00")),
                new DurationLessonDetails(TimeOnly.Parse("13:05"), TimeOnly.Parse("13:50"))]
        },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("14:00"), TimeOnly.Parse("14:45")),
                new DurationLessonDetails(TimeOnly.Parse("14:50"), TimeOnly.Parse("15:35"))]
        },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("15:45"), TimeOnly.Parse("16:30")),
                new DurationLessonDetails(TimeOnly.Parse("16:35"), TimeOnly.Parse("17:20"))]
        },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("17:30"), TimeOnly.Parse("18:15")),
                new DurationLessonDetails(TimeOnly.Parse("18:20"), TimeOnly.Parse("19:05"))]
        },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("19:15"), TimeOnly.Parse("20:20")),
                new DurationLessonDetails(TimeOnly.Parse("20:05"), TimeOnly.Parse("20:50"))]
        }
    };
    static readonly Dictionary<int, IList<DurationLessonDetails>> ShortWithShiftSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("09:15"), TimeOnly.Parse("10:15"))] },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("10:25"), TimeOnly.Parse("11:25"))] },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("11:35"), TimeOnly.Parse("12:35"))] },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("12:45"), TimeOnly.Parse("13:45"))] },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("13:55"), TimeOnly.Parse("14:55"))] },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("15:05"), TimeOnly.Parse("16:05"))] },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("16:15"), TimeOnly.Parse("17:15"))] }
    };
    static readonly Dictionary<int, IList<DurationLessonDetails>> StandartShortSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("08:25"), TimeOnly.Parse("09:25"))] },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("09:35"), TimeOnly.Parse("10:35"))] },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("10:45"), TimeOnly.Parse("11:45"))] },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("11:55"), TimeOnly.Parse("12:55"))] },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("13:00"), TimeOnly.Parse("14:00"))] },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("14:10"), TimeOnly.Parse("15:10"))] },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("15:15"), TimeOnly.Parse("16:15"))] },
    };
    static readonly Dictionary<int, IList<DurationLessonDetails>> SuperShortSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("08:25"), TimeOnly.Parse("08:55"))] },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("09:00"), TimeOnly.Parse("09:30"))] },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("09:35"), TimeOnly.Parse("10:05"))] },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("10:10"), TimeOnly.Parse("10:40"))] },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("10:45"), TimeOnly.Parse("11:15"))] },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("11:20"), TimeOnly.Parse("11:50"))] },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("11:55"), TimeOnly.Parse("12:25"))] },
    };
    static readonly Dictionary<int, IList<DurationLessonDetails>> StandartWithShiftSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("09:15"), TimeOnly.Parse("10:00")),
                new DurationLessonDetails(TimeOnly.Parse("10:10"), TimeOnly.Parse("10:55"))] },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("11:00"), TimeOnly.Parse("11:45")),
                new DurationLessonDetails(TimeOnly.Parse("12:15"), TimeOnly.Parse("13:00"))] },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("13:05"), TimeOnly.Parse("13:50")),
                new DurationLessonDetails(TimeOnly.Parse("14:00"), TimeOnly.Parse("14:45"))] },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("14:50"), TimeOnly.Parse("15:35")),
                new DurationLessonDetails(TimeOnly.Parse("15:45"), TimeOnly.Parse("16:30"))] },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("16:35"), TimeOnly.Parse("17:20")),
                new DurationLessonDetails(TimeOnly.Parse("17:30"), TimeOnly.Parse("18:15"))] },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("18:20"), TimeOnly.Parse("19:05")),
                new DurationLessonDetails(TimeOnly.Parse("19:15"), TimeOnly.Parse("20:00"))] },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("20:05"), TimeOnly.Parse("20:50")),
                new DurationLessonDetails(TimeOnly.Parse("21:00"), TimeOnly.Parse("21:45"))] }
    };
    static readonly Dictionary<int, IList<DurationLessonDetails>> SuperShortWithShiftSchedules = new()
    {
        { 1, [new DurationLessonDetails(TimeOnly.Parse("09:15"), TimeOnly.Parse("09:55"))] },
        { 2, [new DurationLessonDetails(TimeOnly.Parse("10:05"), TimeOnly.Parse("10:45"))] },
        { 3, [new DurationLessonDetails(TimeOnly.Parse("10:55"), TimeOnly.Parse("11:35"))] },
        { 4, [new DurationLessonDetails(TimeOnly.Parse("11:45"), TimeOnly.Parse("12:25"))] },
        { 5, [new DurationLessonDetails(TimeOnly.Parse("12:35"), TimeOnly.Parse("13:15"))] },
        { 6, [new DurationLessonDetails(TimeOnly.Parse("13:25"), TimeOnly.Parse("14:05"))] },
        { 7, [new DurationLessonDetails(TimeOnly.Parse("14:15"), TimeOnly.Parse("14:55"))] }
    };

    public static IList<DurationLessonDetails> GetDurationLessonDetails(this ScheduleItem scheduleItem, ScheduleCallType type = ScheduleCallType.Standart)
    {
        var schedules = type switch
        {
            ScheduleCallType.Standart => StandartSchedules,
            ScheduleCallType.StandartShort => StandartShortSchedules,
            ScheduleCallType.SuperShort => SuperShortSchedules,
            ScheduleCallType.StandartWithShift => StandartWithShiftSchedules,
            ScheduleCallType.SuperShortWithShift => SuperShortWithShiftSchedules,
            ScheduleCallType.ShortWithShift => ShortWithShiftSchedules,
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported ScheduleCallType: {type}")
        };

        if (!schedules.TryGetValue(scheduleItem.Pair, out var scheduleCalls))
        {
            return [];
        }

        return scheduleItem.Number switch
        {
            0 => scheduleCalls,
            1 => [scheduleCalls.First()],
            2 => [scheduleCalls.Last()],
            _ => [],
        };
    }
}