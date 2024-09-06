// See https://aka.ms/new-console-template for more information

using ClientSamgk.Enums;
using ClientSamgk.Interfaces.Client;
var api = new ClientSamgk.ClientSamgk();
await Task.Delay(1000);
foreach (var group in api.Groups.GetGroups())
{
    Console.WriteLine($"#{group.Id} - {group.Name}");
}

foreach (var cab in api.Cabs.GetCabs())
{
    Console.WriteLine($"#{cab.Adress}");
}

foreach (var rasp in api.Sсhedule.GetSchedule(new DateOnly(2024, 09, 04), SheduleSearchType.Cab, "5/512").Lessons)
{
    Console.WriteLine($"{rasp.NumPair}.{rasp.NumLesson} {rasp.SubjectDetails.SubjectName}");
}


foreach (var rasp in api.Sсhedule.GetSchedule(new DateOnly(2024, 09, 04),
             new DateOnly(2024, 09, 05), SheduleSearchType.Cab, "5/512"))
{
    Console.WriteLine($"#{rasp.Date}");

    foreach (var lesson in rasp.Lessons)
    {
        Console.WriteLine($"{lesson.NumPair} {lesson.SubjectDetails.SubjectName}");
    }
}