using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public class Projects
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("result")] public ProjectResult Result { get; set; }
    [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }

}