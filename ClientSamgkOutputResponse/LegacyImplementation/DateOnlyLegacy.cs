namespace ClientSamgkOutputResponse.LegacyImplementation;

public class DateOnlyLegacy
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public DayOfWeek DayOfWeek => GetDayOfWeek(new DateTime(Year, Month, Day));
    public DateOnlyLegacy(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public DateOnlyLegacy()
    {
        
    }

    public DateOnlyLegacy AddDays(int days)
    {
        var current = new DateTime(Year, Month, Day);
        current =current.AddDays(days);
        Year = current.Year;
        Month = current.Month;
        Day = current.Day;
        return this;
    }

    private DayOfWeek GetDayOfWeek(DateTime date)
    {
        return date.DayOfWeek;
    }
} 