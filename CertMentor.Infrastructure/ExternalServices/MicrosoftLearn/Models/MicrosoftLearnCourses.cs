using System.Text.Json.Serialization;

namespace CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Models
{
    public class MicrosoftLearnCourses
    {
        [JsonPropertyName("uid")]
        public string UID { get; init; } = string.Empty;
    }
}
