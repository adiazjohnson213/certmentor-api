using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Application.Interfaces.Catalog
{
    public interface ICertificationRepository : IRepository
    {
        Task<Certification?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Certification>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Certification> AddAsync(Certification certification, CancellationToken cancellationToken = default);
        Task UpdateAsync(Certification certification, CancellationToken cancellationToken = default);
    }
}
