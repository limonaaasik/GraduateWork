using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class ProjectDefects
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("open")] public int Open { get; init; }
}