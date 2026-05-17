namespace CertMentor.Domain.Entities
{
    public class SkillArea
    {
        private readonly List<Topic> _topics = new();
        public IReadOnlyCollection<Topic> Topics => _topics.AsReadOnly();
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int LowestWeightPercentage { get; private set; }
        public int HighestWeightPercentage { get; private set; }
        public int CertificationId { get; private set; }
        public Certification Certification { get; private set; } = null!;

        private SkillArea()
        {
        }

        public static SkillArea Create(string name, int lowestWeightPercentage, int highestWeightPercentage)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentOutOfRangeException.ThrowIfLessThan(lowestWeightPercentage, 0, nameof(lowestWeightPercentage));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(highestWeightPercentage, 100, nameof(highestWeightPercentage));
            if (lowestWeightPercentage > highestWeightPercentage)
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
    }
}
