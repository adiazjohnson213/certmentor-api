namespace CertMentor.Application.DTOs.Catalog
{
    public record SkillAreaResponse(
        string Name,
        int? LowestWeightPercentage,
        int? HighestWeightPercentage
     );
}
