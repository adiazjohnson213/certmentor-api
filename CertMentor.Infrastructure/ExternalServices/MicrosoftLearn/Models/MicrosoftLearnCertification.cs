using System.Text.Json.Serialization;

namespace CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Models
{
    public class MicrosoftLearnCertification
    {
        [JsonPropertyName("uid")]
        public string UID { get; init; } = string.Empty;
        [JsonPropertyName("title")]
        public string Title { get; init; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; init; } = string.Empty;
        [JsonPropertyName("skills")]
        public IReadOnlyCollection<string> Skills { get; init; } = Array.Empty<string>();
        [JsonPropertyName("study_guide")]
        public IReadOnlyCollection<MicrosoftLearnCourses> Courses { get; init; } = Array.Empty<MicrosoftLearnCourses>();

        [JsonPropertyName("exam_duration_in_minutes")]
        public int ExamDurationInMinutes { get; init; }
    }
}
