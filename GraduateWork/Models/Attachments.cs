using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class Attachments
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public Result Result { get; set; }
}