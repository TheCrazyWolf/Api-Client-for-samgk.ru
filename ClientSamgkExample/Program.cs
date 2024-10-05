﻿using ClientSamgk;
using ClientSamgk.Enums;
using ClientSamgk.Interfaces.Client;

namespace ClientSamgkExample;

class Programm
{
    static async Task Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        IClientSamgkApi api = new ClientSamgkApi();

        // Получить список групп
        var groupsArray = await api.Groups.GetGroupsAsync();

        // Получить список преподавателей
        var groupsTeachers = await api.Accounts.GetTeachersAsync();

        // Получение расписание за день
        DateTime dateOnly = new DateTime(2024, 09, 16);
        var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, ScheduleSearchType.Employee, "2294");

        // или с использованием объектов реализующих интерфейсы
        // IOutResultIdentity, IOutResultCab, IOutResultGroup
        var obj = await api.Groups.GetGroupAsync("ис-23-01");

        if (obj is null) throw new Exception($"{nameof(obj)} is null)");

        scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, obj);

        // Получение расписание диапозона дат
        DateTime dateOnlyStart = new DateTime(2024, 09, 16);
        DateTime dateOnlyEnd = new DateTime(2024, 09, 16);

        var resultScheduleCollection = await api.Schedule
            .GetScheduleAsync(dateOnlyStart, dateOnlyEnd, obj);

        // Получение расписание за день по преподавателям, кабинету или группам
        // долгая выгрузка
        var resultScheduleCollectionFromDateAll = await api.Schedule
            .GetAllScheduleAsync(dateOnlyStart, ScheduleSearchType.Employee, 1000);

        // пример вывода расписания
        foreach (var item in scheduleFromDate.Lessons)
        {
            Console.WriteLine($"{item.NumPair}.{item.NumLesson} - {item.SubjectDetails.FullSubjectName}");
        }
    }
}