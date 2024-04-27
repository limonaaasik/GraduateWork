using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class Project
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("code")] public string Code { get; init; }
    [JsonPropertyName("counts")] public ProjectCounts Counts { get; init; }
    [JsonPropertyName("runs")] public ProjectRuns Runs { get; set; }
    [JsonPropertyName("defects")] public ProjectDefects Defects { get; set; }
}