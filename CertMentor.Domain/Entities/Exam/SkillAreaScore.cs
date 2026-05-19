using CertMentor.Domain.Entities.Catalog;

namespace CertMentor.Domain.Entities.Exam
{
    public class SkillAreaScore
    {
        public int Id { get; private set; }
        public float Score { get; private set; }
        public int SkillAreaId { get; private set; }
        public SkillArea SkillArea { get; private set; } = null!;
        public int PerformanceRecordId { get; private set; }
        public PerformanceRecord PerformanceRecord { get; private set; } = null!;

        private SkillAreaScore()
        {
        }

        public static SkillAreaScore Create(float score, int skillAreaId, int performanceRecordId)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(score, 0, nameof(score));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(score, 100, nameof(score));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(skillAreaId, 0, nameof(skillAreaId));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(performanceRecordId, 0, nameof(performanceRecordId));

            return new SkillAreaScore
            {
                Score = score,
                SkillAreaId = skillAreaId,
                PerformanceRecordId = performanceRecordId
            };
        }
    }
}
