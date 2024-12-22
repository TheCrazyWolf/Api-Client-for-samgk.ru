// See https://aka.ms/new-console-template for more information
using ClientSamgk;
using ClientSamgk.Interfaces.Client;
using ClientSamgk.Models;
using ClientSamgkOutputResponse.Enums;

IClientSamgkApi api = new ClientSamgkApi();

var group = await api.Groups.GetGroupAsync("ИС-23-01"); // Получить группу
var groups = await api.Groups.GetGroupsAsync(); // Получить список групп
var teacher = await api.Accounts.GetTeacherAsync("Кулагин Алексей Александрович"); // Получить преподавателя
var teachers = await api.Accounts.GetTeachersAsync(); // Получить список преподавателей
var cab = await api.Cabs.GetCabAsync("501"); // Получить кабинет
var cabs = await api.Cabs.GetCabsAsync(); // Получить список кабинетов
var cabsInCampus = await api.Cabs.GetCabsAsync("5"); // Получить список кабинетов по корпусу

DateOnly dateOnly = new DateOnly(2024, 12, 23); // Дата-пример

var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithSearchType(ScheduleSearchType.Employee, 2294);

var scheduleFromDate = await api.Schedule.GetScheduleAsync(query); // Получение расписание за день или с использованием объектов реализующих интерфейсов: IOutResultIdentity, IOutResultCab, IOutResultGroup

if (group is null)
{
    throw new Exception($"{nameof(group)} is null)");
}

var searchDateAndGroup = new ScheduleQuery().WithDate(dateOnly).WithGroup(group);

scheduleFromDate = await api.Schedule.GetScheduleAsync(searchDateAndGroup);

// Получение расписание диапозона дат
DateOnly dateOnlyStart = new DateOnly(2024, 12, 23);
DateOnly dateOnlyEnd = new DateOnly(2024, 12, 23);

var dateSearchAndGroup = new ScheduleQuery()
    .WithDateRange(dateOnlyStart, dateOnlyEnd)
    .WithGroup(group);

var schedule = await api.Schedule.GetScheduleAsync(dateSearchAndGroup);

// Получение расписание за день по преподавателям, кабинету или группам
var getAll = new ScheduleQuery()
    .WithDate(dateOnlyStart)
    .WithAllForSearchType(ScheduleSearchType.Employee)
    .WithDelay(1000);

var schedules = await api.Schedule.GetScheduleAsync(getAll);

foreach (var item in scheduleFromDate.First().Lessons) // пример вывода расписания
{
    Console.WriteLine($"{item.NumPair}.{item.NumLesson} - {item.SubjectDetails.FullSubjectName}");
}

api.Cache.Clear(); // Принудительно очищает весь кэш
api.Cache.ClearIfOutDate(); // Очистка кэша если данные устарели.
await api.Cache.ClearIfOutDateAsync(); // Очистка кэша если данные устарели. (с поддержкой ожидания)

Console.ReadLine();