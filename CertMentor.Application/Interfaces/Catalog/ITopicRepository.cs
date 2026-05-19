using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Application.Interfaces.Catalog
{
    public interface ITopicRepository
    {
        Task<IReadOnlyCollection<Topic>> GetBySkillAreaIdAsync(int skillAreaId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Topic>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Topic> AddAsync(Topic topic, CancellationToken cancellationToken = default);
        Task UpdateAsync(Topic topic, CancellationToken cancellationToken = default);
    }
}
