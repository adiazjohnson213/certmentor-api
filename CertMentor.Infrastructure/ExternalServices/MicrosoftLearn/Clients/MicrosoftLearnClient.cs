using System.Net.Http.Json;
using CertMentor.Application.Interfaces.Catalog;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Models;

namespace CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Clients
{
    public class MicrosoftLearnClient : IMicrosoftLearnClient
    {
        private const string BaseUrl = "https://learn.microsoft.com/api/catalog";
        private readonly HttpClient _httpClient;

        public MicrosoftLearnClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IReadOnlyCollection<Certification>> GetCertificationsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/?type=mergedCertifications", cancellationToken);
            response.EnsureSuccessStatusCode();

            var catalogResponse = await response.Content.ReadFromJsonAsync<MicrosoftLearnCatalogResponse>(cancellationToken);

            if (catalogResponse is null)
                return Array.Empty<Certification>();

            var result = new List<Certification>();

            foreach (var item in catalogResponse.Certifications.Where(c => c.Skills.Count > 0))
            {
                var certification = Certification.Create(item.UID, item.Title);

                foreach (var skill in item.Skills)
                {
                    var skillArea = SkillArea.Create(skill);
                    certification.AddSkillArea(skillArea);
                }

                result.Add(certification);
            }

            return result.AsReadOnly();
        }
    }
}
