using CertMentor.Domain.Enums;

namespace CertMentor.Application.DTOs.Exam
{
    public record ExamQuestionResponse(
        int Id,
        string Question,
        QuestionType Type,
        IReadOnlyCollection<string> Answers);
}
