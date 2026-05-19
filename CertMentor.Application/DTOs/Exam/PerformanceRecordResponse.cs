namespace CertMentor.Application.DTOs.Exam
{
    public record PerformanceRecordResponse(
        string CertificationCode,
        bool IsPass,
        float Score,
        IReadOnlyCollection<SkillAreaScoreResponse> SkillAreaScores);
}
