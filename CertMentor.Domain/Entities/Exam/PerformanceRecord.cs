namespace CertMentor.Domain.Entities.Exam
{
    public class PerformanceRecord
    {
        private readonly List<SkillAreaScore> _skillAreaScores = new List<SkillAreaScore>();
        public IReadOnlyCollection<SkillAreaScore> SkillAreaScores => _skillAreaScores.AsReadOnly();
        public int Id { get; private set; }
        public bool Result { get; private set; }
        public float Score { get; private set; }
        public int ExamSessionId { get; private set; }
        public ExamSession ExamSession { get; private set; } = null!;

        private PerformanceRecord()
        {
        }

        public static PerformanceRecord Create(bool result, float score, int examSessionId, IEnumerable<SkillAreaScore> skillAreaScores)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(score, 0, nameof(score));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(score, 100, nameof(score));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(examSessionId, 0, nameof(examSessionId));
            ArgumentNullException.ThrowIfNull(skillAreaScores, nameof(skillAreaScores));

            if (!skillAreaScores.Any())
                throw new ArgumentException("At least one skill area score is required.", nameof(skillAreaScores));

            var performanceRecord = new PerformanceRecord
            {
                Result = result,
                Score = score,
                ExamSessionId = examSessionId
            };

            performanceRecord._skillAreaScores.AddRange(skillAreaScores);

            return performanceRecord;
        }
    }
}