using CertMentor.Application.Interfaces.Catalog;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Repositories.Catalog
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(CertMentorDbContext certMentorDbContext) : base(certMentorDbContext)
        {
        }

        public async Task<IReadOnlyCollection<Topic>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.Topics.AsNoTracking().ToListAsync(cancellationToken)).AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Topic>> GetBySkillAreaIdAsync(int skillAreaId, CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.Topics.AsNoTracking().Where(t => t.SkillAreaId == skillAreaId).ToListAsync(cancellationToken)).AsReadOnly();
        }
    }
}
