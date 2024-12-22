# Библиотека для работы с API samgk.ru

Загрузить https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases

### Зависимости
1. Newtonsoft.Json.dll
2. RestSharp.dll
3. RestSharp.Serializers.NewtonsoftJson.dll

### Установка из nuget
1. Имя пакета ClientSamgk
2. Вручную
``
dotnet add package ClientSamgk 
``

# Пример работы с библиотекой

### Создание экземпляра класса
```csharp
IClientSamgkApi api = new ClientSamgkApi();
```

## Преподаватели
### Получение списка преподавателей
```csharp
var teachers = await api.Accounts.GetTeachersAsync();
```
### Получение объекта преподавателя
```csharp
var teacher = await api.Accounts.GetTeacherAsync("кулагин алексей александрович");
```

## Группы
### Получение списка групп
```csharp
var groups = await api.Groups.GetGroupsAsync();
```

### Получение объекта по название группы
```csharp
var group = await api.Groups.GetGroupAsync("ис-23-01");
```

## Кабинеты, корпуса
### Получение списка кабинетов
```csharp
var cabs = await api.Cabs.GetCabsAsync();
```

### Получение списка корпусов
```csharp
var campuses = await api.Cabs.GetCampusesAsync();
```

### Получение списка кабинетов по корпусу
```csharp
var cabsInCampus = await api.Cabs.GetCabsAsync("5"); 
или
var cabsInCampus = await api.Cabs.GetCabsFromCampusAsync("5");
```

## Расписание

### Получение расписания из объектов реализующих интерфейсы
Метод GetScheduleAsync поддерживает получение расписания из объектов, реализующих интерфейсы IResultOutCab, IResultOutGroup, IResultOutIdentity.
```csharp
var group = await api.Groups.GetGroupAsync("ис-23-01");  // group - будет хранится объект реализующих интерфейс IResultOutGroup

ArgumentNullException.ThrowIfNull(query, $"{nameof(obj)} is null)");

var dateSearchAndGroup = new ScheduleQuery()
    .WithDate(new DateOnly(2024, 12, 23))
    .WithGroup(group);

var scheduleFromDateAndGroup = await api.Schedule.GetScheduleAsync(dateSearchAndGroup);
```

### Получение расписания стандартным способом
Метод GetScheduleAsync позволяет получать расписание с помощью перечисления ScheduleSearchType.
```csharp
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithSearchType(ScheduleSearchType.Employee, 2294);

var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```

### Получение расписания используя диапазон дат
Метод GetScheduleAsync поддерживает получение расписания по диапазону дат.
```csharp
DateOnly dateOnlyStart = new DateOnly(2024, 09, 16);
DateOnly dateOnlyEnd = new DateOnly(2024, 09, 17);

var query = new ScheduleQuery()
    .WithDateRange(dateOnlyStart, dateOnlyEnd)
    .WithSearchType(ScheduleSearchType.Employee, 2294)
    .WithDelay(1000); // (по умолчанию 700 мс)

var scheduleFromDates = await api.Schedule.GetScheduleAsync(query);
```

### Получение расписания за весь день по группам/преподавателю/кабинету
```csharp
DateOnly dateOnlyStart = new DateOnly(2024, 09, 16);
var query = new ScheduleQuery()
    .WithDate(dateOnlyStart)
    .WithAllForSearchType(ScheduleSearchType.Employee)
    .WithDelay(1000); // (по умолчанию 700 мс)

var schedules = await api.Schedule.GetScheduleAsync(query);
```


### Установка расписания звонков и скрытие разговоров о важном/Россия мои горизонты
```csharp
var query = new ScheduleQuery()
    .WithDate(new DateOnly(2024, 09, 16))
    .WithSearchType(ScheduleSearchType.Employee, 2288)
    .WithScheduleCallType(ScheduleCallType.StandartShort)
    .WithShowRussianHorizon() // Скрывает Россия - мои горизонты
    .WithShowImportant(); // Скрывает Разговоры о важном

var schedule = await api.Schedule.GetScheduleAsync(query);
```

### Отказ от кэширования расписания
Метод GetScheduleAsync кэширует расписание: прошедшие даты — на 1 месяц, текущие и будущие — на 5-10 минут. Кэширование работает в рамках экземпляра класса. Отказ от кэширования осуществляется с помощью метода WithOverrideCache.
```csharp
var query = new ScheduleQuery()
    .WithDate(new DateOnly(2024, 09, 16))
    .WithSearchType(ScheduleSearchType.Employee, 2288)
    .WithScheduleCallType(ScheduleCallType.StandartShort)
    .WithOverrideCache(true);

var schedule = await api.Schedule.GetScheduleAsync(query);
```


### Принудительная очистка кэша и устаревших данных
По умолчанию при вызове методов происходит очистка устаревших данных, но можно сделать это вручную или очистить все данные.
```csharp
api.Cache.Clear(); // Принудительно очищает весь кэш
api.Cache.ClearIfOutDate(); // Очистка кэша если данные устарели.
await api.Cache.ClearIfOutDateAsync(); // Очистка кэша если данные устарели. (с поддержкой ожидания)
```