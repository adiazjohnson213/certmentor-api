using CertMentor.Application.Interfaces.Exam;
using CertMentor.Domain.Entities.Exam;
using CertMentor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Repositories.Exam
{
    public class PerformanceRecordRepository : BaseRepository<PerformanceRecord>, IPerformanceRecordRepository
    {
        public PerformanceRecordRepository(CertMentorDbContext certMentorDbContext) : base(certMentorDbContext)
        {
        }

        public async Task<IReadOnlyCollection<PerformanceRecord>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.PerformanceRecords.AsNoTracking().ToListAsync(cancellationToken)).AsReadOnly();
        }

        public async Task<PerformanceRecord?> GetByExamSessionIdAsync(int examSessionId, CancellationToken cancellationToken = default)
        {
            return await _certMentorDbContext.PerformanceRecords.SingleOrDefaultAsync(pr => pr.ExamSessionId == examSessionId, cancellationToken);
        }
    }
}
