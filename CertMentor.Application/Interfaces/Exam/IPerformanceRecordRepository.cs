using CertMentor.Domain.Entities.Exam;

namespace CertMentor.Application.Interfaces.Exam
{
    public interface IPerformanceRecordRepository : IRepository
    {
        Task<PerformanceRecord?> GetByExamSessionIdAsync(int examSessionId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<PerformanceRecord>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PerformanceRecord> AddAsync(PerformanceRecord performanceRecord, CancellationToken cancellationToken = default);
        Task UpdateAsync(PerformanceRecord performanceRecord, CancellationToken cancellationToken = default);
    }
}
