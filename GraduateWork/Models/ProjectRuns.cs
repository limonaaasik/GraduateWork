using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class ProjectRuns
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("active")] public int Active { get; init; }
}