using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Groups;

public class SamGkGroupApiResult
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("currator")] public long? Currator { get; set; }
}