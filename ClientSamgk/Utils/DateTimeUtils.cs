namespace ClientSamgk.Utils;

public static class DateTimeUtils
{
    public static IList<DateOnly> GetDateRange(DateOnly startDate, DateOnly endDate)
    {
        var daysCount = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
        var dateRange = new List<DateOnly>(daysCount);

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dateRange.Add(date);
        }

        return dateRange;
    }
}