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
var cabs = await api.Cabs.GetCabsFromCampusAsync("5");
```

## Расписание

### Получение расписания из объектов реализующих интерфейсы
Метод GetScheduleAsync поддерживает получение расписания из объектов, реализующих интерфейсы IResultOutCab, IResultOutGroup, IResultOutIdentity.
Пример:
```csharp
var group = await api.Groups.GetGroupAsync("ис-23-01");  // group - будет хранится объект реализующих интерфейс IResultOutGroup
if (group is null) 
{
    throw new Exception($"{nameof(obj)} is null)");
}

DateOnly dateOnly = new DateOnly(2024,09,16);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, obj);
```

### Получение расписания стандартным способом
Метод GetScheduleAsync позволяет получать расписание с помощью перечисления ScheduleSearchType.
Пример:
```csharp
DateOnly dateOnly = new DateOnly(2024, 09, 16);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, ScheduleSearchType.Employee, 2294);
```

### Получение расписания используя диапазон дат
Метод GetScheduleAsync поддерживает получение расписания по диапазону дат. Параметр 1000 — delay (задержка между запросами, по умолчанию 700 мс).
Пример:
```csharp
DateOnly dateOnlyStart = new DateOnly(2024, 09, 16);
DateOnly dateOnlyEnd = new DateOnly(2024, 09, 16);
var scheduleFromDates = await api.Schedule.GetScheduleAsync(dateOnlyStart, dateOnlyEnd, ScheduleSearchType.Employee, 2294, 1000);
```

### Получение расписания за весь день по группам, преподавателю или кабинету
Метод GetAllScheduleAsync выгружает расписание за день по типу. Параметр 1000 — это delay, задержка между запросами (по умолчанию 700 мс).
Пример:
```csharp
DateOnly dateOnly = new DateOnly(2024, 09, 16);
var resultScheduleCollectionFromDateAll = await api.Schedule.GetAllScheduleAsync(dateOnly, ScheduleSearchType.Employee, 1000);
```


### Установка расписания звонков/скрытие разговоров о важном/мои горизонты
Метод GetScheduleAsync принимает параметры: ScheduleCallType, showImportantLessons и showRussianHorizonLesson. 
Пример получения сокращенного расписания:
```csharp
DateOnly dateOnly = new DateOnly(2024, 09, 16);
var result = await api.Schedule.GetScheduleAsync(date: dateOnly, type: ScheduleSearchType.Employee, id: 2288, 
    scheduleCallType: ScheduleCallType.StandartShort, showRussianHorizonLesson: true, showImportantLessons: true);
```

### Отказ от кэширования расписания
Метод GetScheduleAsync кэширует расписание: прошедшие даты — на 1 месяц, текущие и будущие — на 5-10 минут. Кэширование работает в рамках экземпляра класса. Отказ от кэширования осуществляется с помощью параметра overrideCache.
Пример:
```csharp
DateOnly dateOnly = new DateOnly(2024, 09, 16);
var schedule = await api.Schedule.GetScheduleAsync(date: dateOnly, type: ScheduleSearchType.Employee, id: 2288, 
    scheduleCallType: ScheduleCallType.StandartShort, overrideCache: true);
```


### Принудительная очистка кеша или устаревших данных
По умолчанию при вызове методов происходит очистка устаревших данных, но можно сделать это вручную или очистить все данные.
```csharp
await api.Cache.ClearIfOutDate(); // Очистка устаревших данных
api.Cache.Clear(); // Очистка всех данных
```