using CertMentor.Domain.Enums;

namespace CertMentor.Application.DTOs.Exam
{
    public record ExamSessionResponse(
        int Id,
        string CertificationCode,
        SessionStatus Status,
        DateTime? EndTime,
        IReadOnlyCollection<ExamQuestionResponse> Questions);
}
