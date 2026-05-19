using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Domain.Entities.Exam
{
    public class StudyPlan
    {
        private readonly List<StudyPlanItem> _studyPlanItems = new();
        public IReadOnlyCollection<StudyPlanItem> StudyPlanItems => _studyPlanItems.AsReadOnly();
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int PerformanceRecordId { get; private set; }
        public PerformanceRecord PerformanceRecord { get; private set; } = null!;
        public int CertificationId { get; private set; }
        public Certification Certification { get; private set; } = null!;

        private StudyPlan()
        {
        }

        public static StudyPlan Create(int performanceRecordId, int certificationId, IEnumerable<StudyPlanItem> studyPlanItems)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(performanceRecordId, 0, nameof(performanceRecordId));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(certificationId, 0, nameof(certificationId));
            ArgumentNullException.ThrowIfNull(studyPlanItems, nameof(studyPlanItems));

            if (!studyPlanItems.Any())
                throw new ArgumentException("At least one study plan item is required.", nameof(studyPlanItems));

            var studyPlan = new StudyPlan
            {
                CreatedAt = DateTime.UtcNow,
                PerformanceRecordId = performanceRecordId,
                CertificationId = certificationId
            };

            studyPlan._studyPlanItems.AddRange(studyPlanItems);
            return studyPlan;
        }

    }
}
