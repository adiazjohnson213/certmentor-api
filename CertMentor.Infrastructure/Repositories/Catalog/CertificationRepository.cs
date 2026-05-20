using CertMentor.Application.Interfaces.Catalog;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Repositories.Catalog
{
    public class CertificationRepository : BaseRepository<Certification>, ICertificationRepository
    {
        public CertificationRepository(CertMentorDbContext certMentorDbContext) : base(certMentorDbContext)
        {
        }

        public async Task<IReadOnlyCollection<Certification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.Certifications.AsNoTracking().ToListAsync(cancellationToken)).AsReadOnly();
        }

        public async Task<Certification?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _certMentorDbContext.Certifications.SingleOrDefaultAsync(c => c.Code == code, cancellationToken);
        }
    }
}
