using CertMentor.Application.DTOs.Exam;

namespace CertMentor.Application.Interfaces.Exam
{
    public interface IExamService
    {
        Task<ExamSessionResponse> GenerateExamAsync(CreateExamSessionRequest createExamSessionRequest, CancellationToken cancellationToken = default);
        Task<PerformanceRecordResponse> ValidateAnswersAsync(SubmitExamAnswersRequest submitExamAnswersRequest, CancellationToken cancellationToken = default);
        Task<PerformanceRecordResponse> GeneratePerformanceReportAsync(int examSessionId, CancellationToken cancellationToken = default);
        Task<StudyPlanResponse> GenerateStudyPlanAsync(int examSessionId, CancellationToken cancellationToken = default);
    }
}
