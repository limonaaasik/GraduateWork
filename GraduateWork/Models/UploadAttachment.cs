using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class UploadAttachment
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public List<UploadAttachmentResult> Result { get; set; }
}