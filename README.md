# Библиотека для работы с API samgk.ru

Загрузить https://github.com/TheCrazyWolf/Api-Client-for-samgk.ru/releases

# Зависимости
Эти пакеты нужны для работы библиотеки, вы можете их установить самостоятельно через NuGet или так же внедрить DLL файлы в проект
1. Newtonsoft.Json.dll
2. RestSharp.dll
3. RestSharp.Serializers.NewtonsoftJson.dll

# Подключение библиотеки в проект
Добавьте SamGK_Api.dll и зависимые библиотеки в свой проект

Подключени пространство имен
```C#
using SamGK_Api;
```

Создайте экземпляр класса для работы с библотекой
```C#
var api = new ClientSamgk();
```

# Получение списка групп, преподавателей и кабинетов
```C#
var groupsData = api.Groups.GetGroups();
var teachersData = api.Accounts.GetEmployees();
var cabsData = api.Cabs.GetCabs();
```
При получении списков более 2-раз, Вы будете получать кешированные данные из статичного листа. Если Вы захотите получить свежие данные в рамках одного экземпляра класса добавье во входные параметры опцию forceLoad = true, например:
```C#
var result = api.Groups.GetGroups(forceLoad: true);
```

# Авторизация 
Вы можете авторизоваться и получить инфорацию об учетной записи личного кабинета колледжа, для этого необходимо создать экземлпяр класса CredentialSgk и задать ему параметры Username и Password. Пароль передается в чистом виде, хешированию не подлежит
```C#
ICredentialSgk credentials = new CredentialSgk()
{
    Username = "kulagin",
    Password = "Qwerty"
};
```
Вызовите методы авторизации и передайте ему созданный экземпляр с учетным данными
```C#
var access = api.Accounts.Authorization(credentials);
```
Вам будет возращенны данные о владельце учетной записи: ФИО, группа

# Получение расписания
Вы можете получить расписание передав объект, который вы получили из API, например
```C#
IEmployee account = new Employee()
{
    Id = 1468,
    name = "Кулагин Алексей Александрович"
};
```
за конкретный день:
```C#
DateOnly date = new DateOnly(2023, 11, 20);
```
получение расписания этого сотрудника
```C#
IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(date, account)?.ToArray();
```

Получение расписание по группе:
```C#
IGroup group = new Group()
{
    Id = 308,
    Name = "ИС-22-02"
};

IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(date, group)?.ToArray();
```

Получение расписание по кабинету:
```C#
ICab cabinet = new Cab()
{
    name = "5/526"
};

IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(date, cabinet)?.ToArray();
```

Можно получить диапозон расписания, для этого передайте во входых параметрах две даты - начало и конец.

```C#
DateOnly start = new DateOnly(2023, 09, 01);
DateOnly end = new DateOnly(2023, 11, 20);

IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(start, end, group, 0)?.ToArray();
```
где 0 - задержка в МС между запросами (не обязательный параметр), используйте задержку для имитации живой проверки расписания, в противном случае Вы можете получить блокировку по IP. В рамках сети колледжа Вы можете задать задержку 0 мс

Вы так же можете отправлять запросы не используя экземпляры классов. Но вы должны указать перечисление SheduleSearchType и ID - группы, кабинета или сотрудника. Так же работает расписание по диапозону
```C#
DateOnly date = new DateOnly(2023, 09, 01);
SheduleSearchType type = SheduleSearchType.Employee;
string id = 1468.ToString();

IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(date, type, id)?.ToArray();
// или
IEnumerable<IScheduleDate>? sheduleList = api.Sсhedule.GetSchedule(date, SheduleSearchType.Employee, 1468.ToString())?.ToArray();
```

# Пример возможных действий
Пары у Кулагина А.А. с 15.10.2023 пл 20.11.2023
```C#
DateOnly start = new DateOnly(2023, 10, 15);
DateOnly end = new DateOnly(2023, 11, 20);

var listShedule = await api.Sсhedule
    .GetScheduleAsync(start, end, SheduleSearchType.Employee, 1468.ToString(), 500);

foreach (var item in listShedule)
{
    Console.WriteLine($"Занятия {item.Date}");
    
    foreach (var lesson in item.Lessons)
    {
        Console.WriteLine($"{lesson.num} {lesson.title} {lesson.cab}");
    }
}
```
Группы на дистанционном обучение за 20.11.2023
```C#
DateOnly start = new DateOnly(2023, 11, 20);

var listShedule = api.Sсhedule
    .GetSchedule(start, SheduleSearchType.Cab, "дист_дист")?.ToList();

ICollection<IGroup> groupByElectronicEducation = new List<IGroup>();
IEnumerable<IGroup>? groupsFromApi = api.Groups.GetGroups()?.ToList();

foreach (var item in listShedule)
{
    Console.WriteLine($"Занятия {item.Date}");

    if (item.Lessons.Count() == 0)
        continue;

    foreach (var lesson in item.Lessons)
    {
        if (groupByElectronicEducation.Any(x => x.Name == lesson.nameGroup))
            continue;
    
        groupByElectronicEducation.Add(groupsFromApi.FirstOrDefault(x=> x.Name == lesson.nameGroup));
    }
}

foreach (var group in groupByElectronicEducation)
{
    Console.WriteLine($"{group.Name} ");
}
```

# Модели
# IScheduleDate
```C#
public interface IScheduleDate
{
    public string Date { get; set; }
    public DateOnly DateStructure { get; }
    public IEnumerable<ILesson> Lessons { get; set; }
}
```
# ILesson
```C#
public interface ILesson
{
    public string? num { get; set; } // Номер пары
    public string? title { get; set; } // Название пары
    public string? teachername { get; set; } // ФИО преподавателя, отбражается только при запросе по группе
    public string? nameGroup { get; set; } // Номер группы, отображается только при запросе по преопдавателю
    public string? cab { get; set; } // Кабинет
    public string? resource { get; set; } // Ресурсы, для электронного обучения
}
```


