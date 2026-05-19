using CertMentor.Domain.Entities.Exam;

namespace CertMentor.Application.Interfaces.Exam
{
    public interface IExamSessionRepository
    {
        Task<ExamSession?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<ExamSession>> GetByCertificationIdAsync(int certificationId, CancellationToken cancellationToken = default);
        Task<ExamSession> AddAsync(ExamSession examSession, CancellationToken cancellationToken = default);
        Task UpdateAsync(ExamSession examSession, CancellationToken cancellationToken = default);
    }
}
