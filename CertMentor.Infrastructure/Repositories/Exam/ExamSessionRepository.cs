using CertMentor.Application.Interfaces.Exam;
using CertMentor.Domain.Entities.Exam;
using CertMentor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Repositories.Exam
{
    public class ExamSessionRepository : BaseRepository<ExamSession>, IExamSessionRepository
    {
        public ExamSessionRepository(CertMentorDbContext certMentorDbContext) : base(certMentorDbContext)
        {
        }

        public async Task<IReadOnlyCollection<ExamSession>> GetByCertificationIdAsync(int certificationId, CancellationToken cancellationToken = default)
        {
            return (await _certMentorDbContext.ExamSessions.Where(es => es.CertificationId == certificationId).AsNoTracking().ToListAsync(cancellationToken)).AsReadOnly();
        }

        public async Task<ExamSession?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _certMentorDbContext.ExamSessions.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
