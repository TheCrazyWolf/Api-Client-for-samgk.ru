namespace ClientSamgkOutputResponse.LegacyImplementation;

public class DateOnlyLegacy
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public DateOnlyLegacy(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }
    
    public DateOnlyLegacy(int year, int month, int day, DayOfWeek dayOfWeek)
    {
        Year = year;
        Month = month;
        Day = day;
        DayOfWeek = dayOfWeek;
    }

    public DateOnlyLegacy()
    {
        
    }
}