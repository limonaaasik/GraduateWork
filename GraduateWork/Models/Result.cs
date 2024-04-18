using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class Result
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("filtered")] public int Filtered { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("entities")] public List<Attachment> Entities { get; set; }
}