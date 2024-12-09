using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Education;

public class DisciplineInfo
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("position")] public long Position { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("id_plan")] public long IdPlan { get; set; }
    [JsonProperty("id_parent")] public long IdParent { get; set; }
    [JsonProperty("index_name")] public string IndexName { get; set; }
    [JsonProperty("index_num")] public string IndexNum { get; set; }
    [JsonProperty("fignja")] public long Fignja { get; set; }
    [JsonProperty("variativ")] public long Variativ { get; set; }
    [JsonProperty("dbl_variativ")] public long DblVariativ { get; set; }
    [JsonProperty("id_item")] public long IdItem { get; set; }
    [JsonProperty("name_db")] public string NameDb { get; set; }
    [JsonProperty("PM")] public long PM { get; set; }
    [JsonProperty("OK")] public object OK { get; set; }
    [JsonProperty("vkr_or_gia")] public long VkrOrGia { get; set; }
    [JsonProperty("dop_work")] public long DopWork { get; set; }
    [JsonProperty("procent")] public long Procent { get; set; }
    [JsonProperty("kontrrab")] public object Kontrrab { get; set; }
    [JsonProperty("old_id")] public string OldId { get; set; }
}