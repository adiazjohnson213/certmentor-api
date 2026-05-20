using CertMentor.Application.DTOs.Exam;

namespace CertMentor.Application.Interfaces.Exam
{
    public interface IExamAgentService
    {
        Task<IReadOnlyCollection<ExamQuestionResponse>> GenerateQuestionsAsync(
            string context,
            string certificationCode,
            CancellationToken cancellationToken = default);

        Task<StudyPlanResponse> GenerateStudyPlanAsync(
            PerformanceRecordResponse performanceRecord,
            CancellationToken cancellationToken = default);
    }
}
