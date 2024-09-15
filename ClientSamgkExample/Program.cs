// See https://aka.ms/new-console-template for more information

using ClientSamgk.Enums;

var api = new ClientSamgk.ClientSamgkApi();


var result = await api.Schedule.GetAllScheduleAsync(new DateOnly(2024,09,16), ScheduleSearchType.Group);

Console.WriteLine();