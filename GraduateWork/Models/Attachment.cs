using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class Attachment
{
    [JsonPropertyName("hash")] public string Hash { get; set; }
    [JsonPropertyName("file")] public string File { get; init; }
    [JsonPropertyName("mime")] public string Mime { get; init; }
    [JsonPropertyName("size")] public int Size { get; set; }
    [JsonPropertyName("extension")] public string Extension { get; set; }
    [JsonPropertyName("full_path")] public string FullPath { get; set; }
}