using CertMentor.Application.Interfaces.Catalog;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Repositories.Catalog
{
    public class SkillAreaRepository : BaseRepository<SkillArea>, ISkillAreaRepository
    {
        public SkillAreaRepository(CertMentorDbContext certMentorDbContext) : base(certMentorDbContext)
        {
        }

        public async Task<IReadOnlyCollection<SkillArea>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.SkillAreas.AsNoTracking().ToListAsync(cancellationToken)).AsReadOnly();
        }

        public async Task<IReadOnlyCollection<SkillArea>> GetByCertificationIdAsync(int certificationId, CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.SkillAreas.AsNoTracking().Where(sa => sa.CertificationId == certificationId).ToListAsync(cancellationToken)).AsReadOnly();
        }
    }
}
