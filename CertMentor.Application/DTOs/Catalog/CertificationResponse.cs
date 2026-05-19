namespace CertMentor.Application.DTOs.Catalog
{
    public record CertificationResponse(
        string Code,
        string Name,
        IReadOnlyCollection<SkillAreaResponse> SkillAreas
     );
}
