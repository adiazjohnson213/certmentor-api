using System.Text.Json.Serialization;

namespace CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Models
{
    public class MicrosoftLearnCatalogResponse
    {
        [JsonPropertyName("mergedCertifications")]
        public IReadOnlyCollection<MicrosoftLearnCertification> Certifications { get; init; } = Array.Empty<MicrosoftLearnCertification>();
    }
}
