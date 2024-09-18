// See https://aka.ms/new-console-template for more information

using ClientSamgk;
using ClientSamgk.Enums;
using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;
using ClientSamgkOutputResponse.LegacyImplementation;

public class Program
{
    public static async Task Main(string[] args)
    {
        ClientSamgkApi api = new ClientSamgkApi();

// Получить список групп
        IList<IResultOutGroup> groupsArray = await api.Groups.GetGroupsAsync();

// Получить список преподавателей
        IList<IResultOutIdentity> groupsTeachers = await api.Accounts.GetTeachersAsync();

// Получение расписание за день
        DateOnlyLegacy dateOnly = new DateOnlyLegacy(2024, 09, 16);
        IResultOutScheduleFromDate scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, ScheduleSearchType.Employee, "31669");

// или с использованием объектов реализующих интерфейсы
// IOutResultIdentity, IOutResultCab, IOutResultGroup
        IResultOutGroup obj = await api.Groups.GetGroupAsync("ис-23-01");

        if (obj is null) throw new Exception($"{nameof(obj)} is null)");

        scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, obj);

// Получение расписание диапозона дат
        DateOnlyLegacy dateOnlyStart = new DateOnlyLegacy(2024, 09, 16);
        DateOnlyLegacy dateOnlyEnd = new DateOnlyLegacy(2024, 09, 16);

        IList<IResultOutScheduleFromDate> resultScheduleCollection = await api.Schedule
            .GetScheduleAsync(dateOnlyStart, dateOnlyEnd, obj);

// Получение расписание за день по преподавателям, кабинету или группам
// долгая выгрузка
        IList<IResultOutScheduleFromDate> resultScheduleCollectionFromDateAll = await api.Schedule
            .GetAllScheduleAsync(dateOnlyStart, ScheduleSearchType.Employee, 1000);

// пример вывода расписания

        foreach (IResultOutLesson item in scheduleFromDate.Lessons)
        {
            Console.WriteLine($"{item.NumPair}.{item.NumLesson} - {item.SubjectDetails.SubjectName}");
        }
    }
}