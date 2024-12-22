using ClientSamgkOutputResponse.Enums;
using ClientSamgkOutputResponse.Interfaces.Cabs;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgk.Models;

public sealed class ScheduleQuery
{
    public DateOnly? Date { get; private set; }
    public DateOnly? StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }

    public ScheduleSearchType SearchType { get; private set; }
    public bool WithAllForType { get; private set; }
    public string? SearchId { get; private set; }

    public ScheduleCallType ScheduleCallType { get; private set; } = ScheduleCallType.Standart;
    public bool ShowImportantLessons { get; private set; } = true;
    public bool ShowRussianHorizonLesson { get; private set; } = true;
    public bool OverrideCache { get; private set; }
    public int Delay { get; private set; } = 700;

    public ScheduleQuery WithDate(DateOnly date)
    {
        Date = date;
        return this;
    }

    public ScheduleQuery WithDateRange(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
        return this;
    }

    public ScheduleQuery WithEmployee(IResultOutIdentity employee)
    {
        SearchType = ScheduleSearchType.Employee;
        SearchId = employee.Id.ToString();
        return this;
    }

    public ScheduleQuery WithGroup(IResultOutGroup group)
    {
        SearchType = ScheduleSearchType.Group;
        SearchId = group.Id.ToString();
        return this;
    }

    public ScheduleQuery WithCab(IResultOutCab cab)
    {
        SearchType = ScheduleSearchType.Cab;
        SearchId = cab.Adress;
        return this;
    }

    public ScheduleQuery WithSearchType(ScheduleSearchType searchType, string id)
    {
        SearchType = searchType;
        SearchId = id;
        return this;
    }

    public ScheduleQuery WithSearchType(ScheduleSearchType searchType, long id)
    {
        SearchType = searchType;
        SearchId = id.ToString();
        return this;
    }

    public ScheduleQuery WithAllForSearchType(ScheduleSearchType searchType)
    {
        SearchType = searchType;
        WithAllForType = true;
        return this;
    }

    public ScheduleQuery WithScheduleCallType(ScheduleCallType scheduleCallType)
    {
        ScheduleCallType = scheduleCallType;
        return this;
    }

    public ScheduleQuery WithShowImportant(bool show = true)
    {
        ShowImportantLessons = show;
        return this;
    }

    public ScheduleQuery WithShowRussianHorizon(bool show = true)
    {
        ShowRussianHorizonLesson = show;
        return this;
    }

    public ScheduleQuery WithOverrideCache(bool overrideCache = false)
    {
        OverrideCache = overrideCache;
        return this;
    }

    public ScheduleQuery WithDelay(int delay)
    {
        Delay = delay;
        return this;
    }
}