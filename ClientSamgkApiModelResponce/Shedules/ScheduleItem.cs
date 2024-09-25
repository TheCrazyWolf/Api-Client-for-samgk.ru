using ClientSamgkApiModelResponse.Education;
using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Shedules;

public class ScheduleItem
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("group")] public int Group { get; set; }
    [JsonProperty("groupName")] public string GroupName { get; set; }
    [JsonProperty("discipline")] public int Discipline { get; set; }
    [JsonProperty("disciplineInfo")] public DisciplineInfo DisciplineInfo { get; set; }
    [JsonProperty("disciplineName")] public string DisciplineName { get; set; }
    [JsonProperty("teacher")] public List<int> Teacher { get; set; }
    [JsonProperty("teacherName")] public List<string> TeacherName { get; set; }
    [JsonProperty("cab")] public List<string> Cab { get; set; }
    [JsonProperty("pair")] public int Pair { get; set; }
    [JsonProperty("number")] public int Number { get; set; }
    [JsonProperty("facts_teacher")] public List<object> FactsTeacher { get; set; }
    [JsonProperty("invisible")] public int Invisible { get; set; }
    [JsonProperty("zachet")] public int Zachet { get; set; }
}