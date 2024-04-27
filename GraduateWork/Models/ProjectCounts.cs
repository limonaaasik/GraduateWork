using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class ProjectCounts
{
    [JsonPropertyName("cases")] public int Cases { get; set; }
    [JsonPropertyName("suites")] public int Suites { get; init; }
    [JsonPropertyName("milestones")] public int Milestones { get; init; }
}