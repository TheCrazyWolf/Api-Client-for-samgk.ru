using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Implementation.Schedule;

namespace ClientSamgk.CallSchedules;

public static class GenerationCallExtensions
{
    public const int DefaultDurationLessonInMinute = 45;
    public const int DefaultChillTimeInMinute = 5;
    public const int DefaultBigChillTimeInMinute = 30;
    public static readonly TimeOnly DefaultFirstTimeOnly = new TimeOnly(8, 25);
    
    public static IList<DurationLessonDetails> GetDurationsFromScheduleItem(this ScheduleItem scheduleItem, DateOnly date)
    {
        bool isMondayOrTuesday = (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday) &&
                                 (date.Month != 6 && date.Month != 7);
        
        return isMondayOrTuesday ? scheduleItem.GenerateDefaultScheduleCallsForMondayAndThuesday() 
            : scheduleItem.GenerateDefaultScheduleCalls();
    }
    
 private static IList<DurationLessonDetails> GenerateDefaultScheduleCallsForMondayAndThuesday(this ScheduleItem scheduleItem)
{
    IList<DurationLessonDetails> durationlessons = new List<DurationLessonDetails>();
    TimeOnly beginTime = DefaultFirstTimeOnly;

    bool isFirst2polPari = true;
    bool isSkippedObed = false;

    // Обрабатываем пары
    for (int currentPair = 0; currentPair <= scheduleItem.Pair; currentPair++)
    {
        // Обрабатываем номер пары для данного scheduleItem
        if (currentPair == scheduleItem.Pair)
        {
            // Обработка для каждого конкретного случая (0, 1, 2)
            switch (scheduleItem.Number)
            {
                case 0:
                    // Обработка для пары 0
                    for (int i = 0; i < 2; i++)
                    {
                        var start = beginTime;
                        var endTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                        beginTime = endTime;
                        durationlessons.Add(new DurationLessonDetails(start, endTime));
                        
                        // После первого урока добавляем два перерыва
                        if (i == 0) 
                        {
                            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute * 2); // Два перерыва
                        }
                        else 
                        {
                            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); // Один перерыв
                        }
                    }
                    return durationlessons;

                case 1:
                    // Обработка для пары 1
                    var start1 = beginTime;
                    var end1 = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                    beginTime = end1;
                    durationlessons.Add(new DurationLessonDetails(start1, end1));
                    beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute * 2); // Два перерыва
                    return durationlessons;

                case 2:
                    // Обработка для пары 2
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0) continue; // Пропускаем первый шаг
                        var start2 = beginTime;
                        var end2 = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                        beginTime = end2;
                        durationlessons.Add(new DurationLessonDetails(start2, end2));
                        beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); // Один перерыв
                    }
                    return durationlessons;
            }
        }

        // Если это не последняя пара, добавляем стандартное время для урока и перерыва
        if (currentPair == 0)
        {
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); // Урок
            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); // Перерыв
        }

        if (currentPair > 0)
        {
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); // Урок

            if (currentPair == 2)
            {
                // Специфическая логика для 2 пары
                if (isFirst2polPari)
                {
                    beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); // Дополнительный перерыв
                    beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); // Урок
                    isFirst2polPari = false;
                }

                beginTime = beginTime.AddMinutes(isSkippedObed ? 5 : DefaultBigChillTimeInMinute); // Перерыв для обеда
                isSkippedObed = true;
            }
            else
            {
                beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute * 2); // Два перерыва между парами
            }
        }
    }

    return durationlessons;
}

    
    private static IList<DurationLessonDetails> GenerateDefaultScheduleCalls(this ScheduleItem scheduleItem)
    {
        IList<DurationLessonDetails> durationlessons = new List<DurationLessonDetails>();
        TimeOnly beginTime = DefaultFirstTimeOnly;
        
        for (int currentPair = 0; currentPair <= scheduleItem.Pair; currentPair++)
        {
            if (currentPair == scheduleItem.Pair)
            {
                switch (scheduleItem.Number)
                {
                    case 0:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            var start = beginTime;
                            var endTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                            beginTime = endTime;
                            durationlessons.Add(new DurationLessonDetails(start, endTime)); 
                            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
                        }
                        return durationlessons;
                    }
                    case 1:
                    {
                        var start = beginTime;
                        var endTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                        beginTime = endTime;
                        durationlessons.Add(new DurationLessonDetails(start, endTime)); // первая пара
                        beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
                        return durationlessons;
                    }
                    case 2:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if(i is 0) continue;
                            var start = beginTime;
                            var endTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                            beginTime = endTime;
                            durationlessons.Add(new DurationLessonDetails(start, endTime)); // первая пара
                            beginTime = currentPair != 6 ? beginTime.AddMinutes(DefaultChillTimeInMinute) : beginTime.AddMinutes(DefaultBigChillTimeInMinute - 5);
                        }
                        return durationlessons;
                    }
                }
            }

            if (currentPair <= 0) continue;
            
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); 
            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); 
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); 
            
            if(currentPair is 2)
            {
                beginTime = beginTime.AddMinutes(DefaultBigChillTimeInMinute);
                continue;
            }
            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); 
            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
        }

        return durationlessons;
    }
}