namespace CertMentor.Application.DTOs.Exam
{
    public record StudyPlanResponse(int Id, DateTime CreatedAt, IReadOnlyCollection<StudyPlanItemResponse> StudyPlanItems);
}
