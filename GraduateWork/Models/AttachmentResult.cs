using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class AttachmentResult
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public Attachment Result { get; set; }
}