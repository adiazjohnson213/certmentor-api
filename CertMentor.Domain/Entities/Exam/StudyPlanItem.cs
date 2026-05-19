namespace CertMentor.Domain.Entities.Exam
{
    public class StudyPlanItem
    {
        public int Id { get; private set; }
        public string MicrosoftLearnUnit { get; private set; } = string.Empty;
        public int TimeInMinutes { get; private set; }
        public bool IsCompleted { get; private set; }
        public int StudyPlanId { get; private set; }
        public StudyPlan StudyPlan { get; private set; } = null!;

        private StudyPlanItem()
        {
        }

        public static StudyPlanItem Create(string microsoftLearnUnit, int timeInMinutes, int studyPlanId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(microsoftLearnUnit, nameof(microsoftLearnUnit));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(timeInMinutes, 0, nameof(timeInMinutes));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(studyPlanId, 0, nameof(studyPlanId));

            return new StudyPlanItem
            {
                MicrosoftLearnUnit = microsoftLearnUnit,
                TimeInMinutes = timeInMinutes,
                IsCompleted = false,
                StudyPlanId = studyPlanId
            };
        }
    }
}
