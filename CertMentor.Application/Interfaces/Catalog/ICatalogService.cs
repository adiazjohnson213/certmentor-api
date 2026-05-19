using CertMentor.Application.DTOs.Catalog;

namespace CertMentor.Application.Interfaces.Catalog
{
    public interface ICatalogService
    {
        Task<IReadOnlyCollection<CertificationResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CertificationResponse> GetByCodeAsync(string certificationCode, CancellationToken cancellationToken = default);
        Task SyncAsync(string certificationCode, CancellationToken cancellationToken = default);
    }
}
