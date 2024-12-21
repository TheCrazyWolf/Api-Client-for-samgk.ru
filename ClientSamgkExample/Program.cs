// See https://aka.ms/new-console-template for more information
using ClientSamgk;
using ClientSamgk.Interfaces.Client;
using ClientSamgkOutputResponse.Enums;

IClientSamgkApi api = new ClientSamgkApi();

//var groups = await api.Groups.GetGroupsAsync(); // Получить список групп
//var groupsTeachers = await api.Accounts.GetTeachersAsync(); // Получить список преподавателей
//var cabsInCampus = await api.Cabs.GetCabsAsync("5"); // Получить список кабинетов по корпусу
//var cab = await api.Cabs.GetCabAsync("501"); // Получить кабинет

DateOnly dateOnly = new DateOnly(2024, 12, 23); // Дата
//var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, ScheduleSearchType.Employee, "2294"); // Получение расписание за день
var group = await api.Groups.GetGroupAsync("ис-24-07"); // или с использованием объектов реализующих интерфейсов: IOutResultIdentity, IOutResultCab, IOutResultGroup

if (group is null)
{
    throw new Exception($"{nameof(group)} is null)");
}

var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, group);

// Получение расписание диапозона дат
//DateOnly dateOnlyStart = new DateOnly(2024, 12, 23);
//DateOnly dateOnlyEnd = new DateOnly(2024, 12, 23);

//var resultScheduleCollection = await api.Schedule.GetScheduleAsync(dateOnlyStart, dateOnlyEnd, group);
//var resultScheduleCollectionFromDateAll = await api.Schedule.GetAllScheduleAsync(dateOnlyStart, ScheduleSearchType.Employee, delay: 1000); // Получение расписание за день по преподавателям, кабинету или группам (долгая выгрузка)

foreach (var item in scheduleFromDate.Lessons) // пример вывода расписания
{
    var f = item.Durations.FirstOrDefault();
    Console.WriteLine($"{item.NumPair}.{item.NumLesson} - {f.StartTime} | {f.EndTime} - {item.SubjectDetails.FullSubjectName}");
}

Console.ReadLine();