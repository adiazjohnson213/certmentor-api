namespace CertMentor.Domain.Entities.Catalog
{
    public class SkillArea
    {
        private readonly List<Topic> _topics = new();
        public IReadOnlyCollection<Topic> Topics => _topics.AsReadOnly();
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int? LowestWeightPercentage { get; private set; }
        public int? HighestWeightPercentage { get; private set; }
        public bool IsActive { get; private set; } = true;
        public int CertificationId { get; private set; }
        public Certification Certification { get; private set; } = null!;

        private SkillArea()
        {
        }

        public static SkillArea Create(string name, int? lowestWeightPercentage = null, int? highestWeightPercentage = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            if (lowestWeightPercentage.HasValue)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(lowestWeightPercentage.Value, 0, nameof(lowestWeightPercentage));
            }
            if (highestWeightPercentage.HasValue)
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(highestWeightPercentage.Value, 100, nameof(highestWeightPercentage));
            }
            if (lowestWeightPercentage.HasValue && highestWeightPercentage.HasValue && lowestWeightPercentage.Value > highestWeightPercentage.Value)
            {
                throw new ArgumentException("Lowest weight cannot be greater than highest weight.");
            }

            return new SkillArea
            {
                Name = name,
                LowestWeightPercentage = lowestWeightPercentage,
                HighestWeightPercentage = highestWeightPercentage
            };
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
