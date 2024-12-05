using ClientSamgkApiModelResponse.Shedules;
using ClientSamgkOutputResponse.Implementation.Schedule;

namespace ClientSamgk.CallSchedules;

public static class GenerationCallExtensions
{
    public const int DefaultDurationLessonInMinute = 45;
    public const int DefaultChillTimeInMinute = 5;
    public const int DefaultBigChillTimeInMinute = 30;
    public static readonly TimeOnly DefaultFirstTimeOnly = new TimeOnly(8, 25);
    
    public static IList<DurationLessonDetails> GetDurationsFromScheduleItem(this ScheduleItem scheduleItem, DateOnly date,
        bool shortable = false)
    {
     
        bool isMondayOrTuesday = date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday;

        return isMondayOrTuesday ? scheduleItem.GenerateDefaultScheduleCallsForMondayAndThuesday() 
            : scheduleItem.GenerateDefaultScheduleCalls();
    }
    
    private static IList<DurationLessonDetails> GenerateDefaultScheduleCallsForMondayAndThuesday(this ScheduleItem scheduleItem)
    {
        IList<DurationLessonDetails> durationlessons = new List<DurationLessonDetails>();
        TimeOnly beginTime = DefaultFirstTimeOnly;
        
        for (int currentPair = 0; currentPair <= scheduleItem.Pair; currentPair++)
        {
            if (currentPair is 5)
            {
                Console.WriteLine();
            }
            
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
                            if (currentPair >= 5 && i is 0) beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute + DefaultChillTimeInMinute);
                            if(currentPair >= 5 && i is 1) beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
                        }
                        return durationlessons;
                    }
                    case 1:
                    {
                        var start = beginTime;
                        var endTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                        beginTime = endTime;
                        durationlessons.Add(new DurationLessonDetails(start, endTime)); 
                        if (currentPair >= 5) beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute + DefaultChillTimeInMinute);
                        else beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
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
                            durationlessons.Add(new DurationLessonDetails(start, endTime));
                            if(currentPair >= 5 && i is 1) beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
                            else beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
                        }
                        return durationlessons;
                    }
                }
            }
            
            if (currentPair == 0)
            {
                beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
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
    private static IList<DurationLessonDetails> GenerateDefaultScheduleCalls(this ScheduleItem scheduleItem)
    {
        IList<DurationLessonDetails> durationlessons = new List<DurationLessonDetails>();
        TimeOnly beginTime = DefaultFirstTimeOnly;

        // Генерация расписания для всех пар
        for (int currentPair = 0; currentPair <= scheduleItem.Pair; currentPair++)
        {
            // Если текущая пара совпадает с номером пары, для которой генерируется время, рассчитываем время начала и окончания
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
            
            /*if (currentPair == 0 && isMondayOrTuesday)
            {
                beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute);
                beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute);
            }*/

            if (currentPair <= 0) continue;
            
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); // конец текущей пары
            beginTime = beginTime.AddMinutes(DefaultChillTimeInMinute); // перемена
            beginTime = beginTime.AddMinutes(DefaultDurationLessonInMinute); // конец текущей пары
            
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