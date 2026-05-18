using CertMentor.Domain.Entities.Catalog;
using CertMentor.Domain.Enums;

namespace CertMentor.Domain.Entities.Exam
{
    public class ExamSession
    {
        private readonly List<ExamQuestion> _questions = new();
        public IReadOnlyCollection<ExamQuestion> Questions => _questions.AsReadOnly();
        public int Id { get; private set; }
        public SessionStatus Status { get; private set; } = SessionStatus.NotStarted;
        public bool? IsPass { get; private set; }
        public float? Score { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public int CertificationId { get; private set; }
        public Certification Certification { get; private set; } = null!;

        private ExamSession()
        {
        }

        public static ExamSession Create(int certificationId)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(certificationId, 0, nameof(certificationId));

            return new ExamSession
            {
                Status = SessionStatus.InProgress,
                StartedAt = DateTime.UtcNow,
                CertificationId = certificationId
            };
        }

    }
}
