using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Application.Interfaces.Catalog
{
    public interface IMicrosoftLearnClient
    {
        Task<IReadOnlyCollection<Certification>> GetCertificationsAsync(CancellationToken cancellationToken = default);
    }
}
