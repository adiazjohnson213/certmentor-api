namespace CertMentor.Application.DTOs.Exam
{
    public record SubmitExamAnswersRequest(int ExamSessionId, IReadOnlyCollection<UserAnswerRequest> UserAnswers);
}
