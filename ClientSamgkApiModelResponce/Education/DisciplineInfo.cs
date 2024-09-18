using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Education;

public class DisciplineInfo
{
    public long Id { get; set; }
    public long Position { get; set; }
    public string Type { get; set; }
    public long IdPlan { get; set; }
    public long IdParent { get; set; }
    [JsonProperty("index_name")]
    public string IndexName { get; set; }
    [JsonProperty("index_num")]
    public string IndexNum { get; set; }
    public long Fignja { get; set; }
    public long Variativ { get; set; }
    public long DblVariativ { get; set; }
    public long IdItem { get; set; }
    public string NameDb { get; set; }
    public long PM { get; set; }
    public object OK { get; set; }
    public long VkrOrGia { get; set; }
    public long DopWork { get; set; }
    public long Procent { get; set; }
    public object Kontrrab { get; set; }
    public string OldId { get; set; }
}