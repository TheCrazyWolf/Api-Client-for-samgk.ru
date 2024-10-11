# Библиотека для работы с API samgk.ru

Загрузить https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases

### Зависимости
1. Newtonsoft.Json.dll
2. RestSharp.dll
3. RestSharp.Serializers.NewtonsoftJson.dll

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
var obj = await api.Accounts.GetTeacherAsync("кулагин алексей александрович");
```

## Группы
### Получение списка групп
```csharp
var groups = await api.Groups.GetGroupsAsync();
```

### Получение объекта по название группы
```csharp
var obj = await api.Groups.GetGroupAsync("ис-23-01");
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
Метод GetScheduleAsync поддерживает получение расписание из объектов
реализующих интерфейс IResultOutCab, IResultOutGroup, IResultOutIdentity
Пример:
```csharp
var obj = await api.Groups.GetGroupAsync("ис-23-01"); 
if (obj is null) throw new Exception($"{nameof(obj)} is null)");

// obj - будет хранится объект реализующих интерфейс IResultOutGroup
DateOnly dateOnly = new DateOnly(2024,09,16);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, obj);
```

### Получение расписания стандартным способом
Метод GetScheduleAsync поддерживает получение расписание путем указания
перечисления ScheduleSearchType
Пример:
```csharp
DateOnly dateOnly = new DateOnly(2024,09,16);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(dateOnly, ScheduleSearchType.Employee, 2294);
```

### Получение расписания используя диапазон дат
Метод GetScheduleAsync поддерживает получение расписания из диапазона дат. Где 1000 - в параметрах, это delay - задержка
между запросами. По умолчанию 700 мс.
Пример:
```csharp
DateOnly dateOnlyStart = new DateOnly(2024,09,16);
DateOnly dateOnlyEnd = new DateOnly(2024,09,16);
var scheduleFromDates = await api.Schedule.GetScheduleAsync(dateOnlyStart, dateOnlyEnd, ScheduleSearchType.Employee, 2294, 1000);
```

### Получение расписания за весь день по группам, преподавателю или кабинету
Метод GetAllScheduleAsync выгружает расписание за весь день по определенному типу
Где 1000 - в параметрах, это delay - задержка
между запросами. По умолчанию 700 мс.
Пример:
```csharp
DateOnly dateOnly = new DateOnly(2024,09,16);
var resultScheduleCollectionFromDateAll = await api.Schedule.GetAllScheduleAsync(dateOnly, ScheduleSearchType.Employee, 1000);
```