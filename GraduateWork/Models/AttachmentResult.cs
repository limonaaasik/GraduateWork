using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class AttachmentResult
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public Attachment Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }

    public override string? ToString()
    {
        return $"{nameof(Status)}: {Status}, {nameof(Result)}: {Result}";
    }
}