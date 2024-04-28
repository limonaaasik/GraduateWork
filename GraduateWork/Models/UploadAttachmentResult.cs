using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class UploadAttachmentResult
{
    [JsonPropertyName("filename")] public string FileName { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
    [JsonPropertyName("extension")] public string Extension { get; set; }
    [JsonPropertyName("hash")] public string Hash { get; set; }
    [JsonPropertyName("mime")] public string Mime { get; set; }
    [JsonPropertyName("team")] public string Team { get; set; }
}