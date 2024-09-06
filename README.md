# Библиотека для работы с API samgk.ru

Загрузить https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases
# Что нового
1. Собственный результат IResultOutScheduleFromDate из библиотеки
2. Обновлены модели апи

# Зависимости
1. Newtonsoft.Json.dll
2. RestSharp.dll
3. RestSharp.Serializers.NewtonsoftJson.dll

# Сборка Nuget пакета из исходников
```C#
dotnet pack
```

# Подключение библиотеки в проект
Вариант №1 Добавьте SamGK_Api.dll и зависимые библиотеки в свой проект

Вариант №2 Добавьте Nuget пакеты в локальную ветку и установить из NUGET


Создайте экземпляр класса для работы с библотекой
```C#
var api = new ClientSamgk();
```
# Пример использования методов

```C#
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
             new DateOnly(2024, 09, 09), SheduleSearchType.Cab, "5/512"))
{
    Console.WriteLine($"#{rasp.Date}");

    foreach (var lesson in rasp.Lessons)
    {
        Console.WriteLine($"{lesson.NumPair} {lesson.SubjectDetails.SubjectName}");
    }
}
```