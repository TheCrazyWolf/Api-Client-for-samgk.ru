# Библиотека для работы с API samgk.ru

Загрузить https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases

### Зависимости
1. Newtonsoft.Json.dll
2. RestSharp.dll
3. RestSharp.Serializers.NewtonsoftJson.dll

### Установка из nuget
1. Имя пакета ClientSamgk
2. или вручную
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

### Построение запроса
Метод GetScheduleAsync принимает ScheduleQuery. Для выполнения запроса 
необходимо собрать свой запрос используя группу методов, например:

### Стандартный запрос
Получить расписание за конкретный день, указать перечисление ScheduleSearchType
```csharp
DateOnly dateOnly = new DateOnly(2024,09,16);
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithSearchType(ScheduleSearchType.Employee, 2294);
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```

### Запрос с объектами реализующих интерфейсы
такие как IResultOutCab, IResultOutGroup, IResultOutIdentity
Пример:
```csharp
var teachers = await api.Accounts.GetTeachersAsync();
DateOnly dateOnly = new DateOnly(2024,09,16);
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithEmployee(teachers.First());
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```

### Получение расписания используя диапазон дат
Используйте метод WithDateRange для передачи диапазон дат по расписанию.
Обратите внимание, что по умолчанию настроена задержка в 700 мс.
Вы можете настраивать нужную вам задержку с помощью метода WithDelay
Пример:
```csharp
var teachers = await api.Accounts.GetTeachersAsync();
DateOnly start = new DateOnly(2024,09,16);
DateOnly end = new DateOnly(2024,09,17);
var query = new ScheduleQuery()
    .WithDateRange(start, end)
    .WithDelay(500)
    .WithEmployee(teachers.First());
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```

### Получение расписания за весь день по группам, преподавателю или кабинету

Пример:
```csharp
var query = new ScheduleQuery()
    .WithDate(dateOnlyStart)
    .WithAllForSearchType(ScheduleSearchType.Employee)
    .WithDelay(1000);
var resultScheduleCollectionFromDateAll = await api.Schedule.GetScheduleAsync(query);
```


### Установка расписания звонков/ скрытие разговоров о важном/мои горизонты
Методы WithShowImportant, WithShowRussianHorizon принимают параметры на скрытие и показ 
внеурочный занятий.

Метод WithScheduleCallType принимает перечисление типа ScheduleCallType, чтобы
получить нужное расписание звонков
```csharp
var groups = await api.Groups.GetGroupsAsync();
DateOnly dateOnly = new DateOnly(2024,09,16);
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithShowImportant(true)
    .WithShowRussianHorizon(false)
    .WithScheduleCallType(ScheduleCallType.StandartWithShift)
    .WithGroup(groups.First());
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```

### Отказ от кеширования расписания
Метод GetScheduleAsync по умолчанию кеширует расписание в область оперативной памяти с разными сроком жизни, 
для того чтобы не обращаться к серверам повторно. По умолчанию, прошедшие даты кешируется с длительностью 1 месяц, сегодняшние
и последующие в 5-10 минут. Кеширование производится в рамках одного экземпляра класса.

Отказ от кеширования производится методом WithOverrideCache
```csharp
var groups = await api.Groups.GetGroupsAsync();
DateOnly dateOnly = new DateOnly(2024,09,16);
var query = new ScheduleQuery()
    .WithDate(dateOnly)
    .WithOverrideCache(true)
    .WithGroup(groups.First());
var scheduleFromDate = await api.Schedule.GetScheduleAsync(query);
```


### Принудительная очистка кеша или устаревших данных
По умолчанию при вызове любых методов из библиотеки запускается процесс очистки
устаревших данных, но вы можете сделать это вручную или очистить полностью все данные
```csharp
// Очистка устаревших данных
await api.Cache.ClearIfOutDate();

// Очистка всего
api.Cache.Clear();
```