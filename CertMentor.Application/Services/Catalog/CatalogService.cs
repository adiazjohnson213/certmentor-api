using CertMentor.Application.DTOs.Catalog;
using CertMentor.Application.Interfaces.Catalog;

namespace CertMentor.Application.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IMicrosoftLearnClient _microsoftLearnClient;

        public CatalogService(ICertificationRepository certificationRepository, IMicrosoftLearnClient microsoftLearnClient)
        {
            _certificationRepository = certificationRepository;
            _microsoftLearnClient = microsoftLearnClient;
        }
        public async Task<IReadOnlyCollection<CertificationResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var certifications = await _certificationRepository.GetAllAsync(cancellationToken);
            return certifications.Select(c => new CertificationResponse(c.Code, c.Name, c.SkillAreas.Select(sa => new SkillAreaResponse(sa.Name, sa.LowestWeightPercentage, sa.HighestWeightPercentage))
                                    .ToList().AsReadOnly()))
                                    .ToList().AsReadOnly();
        }

        public async Task<CertificationResponse> GetByCodeAsync(string certificationCode, CancellationToken cancellationToken = default)
        {
            var certification = await _certificationRepository.GetByCodeAsync(certificationCode, cancellationToken);
            if (certification == null)
                throw new InvalidOperationException("Certification not found");

            return new CertificationResponse(certification.Code, certification.Name, certification.SkillAreas.Select(sa => new SkillAreaResponse(sa.Name, sa.LowestWeightPercentage, sa.HighestWeightPercentage))
                .ToList().AsReadOnly());
        }

        public async Task SyncAsync(CancellationToken cancellationToken = default)
        {
            var microsoftCertifications = await _microsoftLearnClient.GetCertificationsAsync(cancellationToken);
            var dataBaseCertifications = await _certificationRepository.GetAllAsync(cancellationToken);

            foreach (var certification in microsoftCertifications)
            {
                if (certification == null) continue;

                var existingCertification = dataBaseCertifications.SingleOrDefault(c => c.Code == certification.Code);
                if (existingCertification == null)
                {
                    await _certificationRepository.AddAsync(certification, cancellationToken);
                }
                else
                {
                    existingCertification.Update(certification.Name, certification.SkillAreas.Select(sa => sa.Name).ToList().AsReadOnly());
                }
            }

            foreach (var certification in dataBaseCertifications)
            {
                if (!microsoftCertifications.Any(mc => mc.Code == certification.Code))
                {
                    certification.Deactivate();
                }
            }

            await _certificationRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
