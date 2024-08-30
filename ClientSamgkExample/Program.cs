// See https://aka.ms/new-console-template for more information

using SamGK_Api;
using SamGK_Api.Interfaces.Client;

var api = new ClientSamgk();

foreach (var group in api.Groups.GetGroups())
{
    Console.WriteLine($"#{group.Id} - {group.Name}");
}

foreach (var cab in api.Cabs.GetCabs())
{
    Console.WriteLine($"#{cab.Name}");
}

foreach (var employee in api.Accounts.GetEmployees(true))
{
    Console.WriteLine($"#{employee.Id} - {employee.Name}");
}

foreach (var employee in api.Accounts.GetEmployees(true))
{
    Console.WriteLine($"#{employee.Id} - {employee.Name}");
}

foreach (var rasp in api.Sсhedule.GetSchedule(new DateOnly(2024, 04, 10),
             new DateOnly(2024, 04, 18), SheduleSearchType.Cab, "дист_дист"))
{
    Console.WriteLine($"#{rasp.Date}");

    foreach (var lesson in rasp.Lessons)
    {
        Console.WriteLine($"{lesson.Num} {lesson.Title}");
    }
}