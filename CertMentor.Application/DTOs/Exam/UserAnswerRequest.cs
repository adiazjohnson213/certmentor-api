namespace CertMentor.Application.DTOs.Exam
{
    public record UserAnswerRequest(int ExamQuestionId, IReadOnlyCollection<string> Answers);
}
