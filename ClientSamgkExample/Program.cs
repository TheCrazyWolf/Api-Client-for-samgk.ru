// See https://aka.ms/new-console-template for more information
using ClientSamgk;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgkOutputResponse.Enums;

IClientSamgkApi api = new ClientSamgkApi();

// Получить список групп
var groupsArray = await api.Groups.GetGroupsAsync();

// Получить список преподавателей
var teachers = await api.Accounts.GetTeachersAsync();

// Получение расписание за день
DateOnly dateOnly = new DateOnly(2024,09,16);
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithSearchType(ScheduleSearchType.Employee, 2294);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);

// или с использованием объектов реализующих интерфейсы
// IOutResultIdentity, IOutResultCab, IOutResultGroup
var obj = await api.Groups.GetGroupAsync("ис-23-01");

if (obj is null) throw new Exception($"{nameof(obj)} is null)");

query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithGroup(obj);
scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
    
// Получение расписание диапозона дат
DateOnly dateOnlyStart = new DateOnly(2024,09,16);
DateOnly dateOnlyEnd = new DateOnly(2024,09,16);

query = new ScheduleQuery()
    .WithDateRange(dateOnlyStart, dateOnlyEnd)
    .WithGroup(obj);
var resultScheduleCollection = await api.Schedule
    .GetScheduleAsync(query);
    
// Получение расписание за день по преподавателям, кабинету или группам
// долгая выгрузка
query = new ScheduleQuery()
    .WithDate(dateOnlyStart)
    .WithAllForSearchType(ScheduleSearchType.Employee)
    .WithDelay(1000);
var resultScheduleCollectionFromDateAll = await api.Schedule
    .GetScheduleAsync(query);
    
// пример вывода расписания

foreach (var item in scheduleFromDate.FirstOrDefault().Lessons)
{
    Console.WriteLine($"{item.NumPair}.{item.NumLesson} - {item.SubjectDetails.FullSubjectName}");
}
    