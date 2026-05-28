using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Application.Interfaces.Catalog
{
    public interface ISkillAreaRepository : IRepository
    {
        Task<IReadOnlyCollection<SkillArea>> GetByCertificationIdAsync(int certificationId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<SkillArea>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<SkillArea> AddAsync(SkillArea skillArea, CancellationToken cancellationToken = default);
        Task UpdateAsync(SkillArea skillArea, CancellationToken cancellationToken = default);
    }
}
