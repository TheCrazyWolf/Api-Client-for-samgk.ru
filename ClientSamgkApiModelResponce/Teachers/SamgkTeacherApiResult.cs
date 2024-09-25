using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Teachers;

public class SamgkTeacherApiResult
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
}