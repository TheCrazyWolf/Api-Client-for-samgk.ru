using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ClientSamgkApiModelResponse.Education;

public class DisciplineInfo
{
    public int Id { get; set; }
    public int Position { get; set; }
    public string Type { get; set; }
    public int IdPlan { get; set; }
    public int IdParent { get; set; }
    [JsonProperty("index_name")]
    public string IndexName { get; set; }
    [JsonProperty("index_num")]
    public string IndexNum { get; set; }
    public int Fignja { get; set; }
    public int Variativ { get; set; }
    public int DblVariativ { get; set; }
    public int IdItem { get; set; }
    public string NameDb { get; set; }
    public int PM { get; set; }
    public object OK { get; set; }
    public int VkrOrGia { get; set; }
    public int DopWork { get; set; }
    public int Procent { get; set; }
    public object Kontrrab { get; set; }
    public string OldId { get; set; }
}