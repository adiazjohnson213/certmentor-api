namespace CertMentor.Domain.Entities.Catalog
{
    public class Topic
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int SkillAreaId { get; private set; }
        public SkillArea SkillArea { get; private set; } = null!;

        private Topic()
        {
        }

        public static Topic Create(string name, string description)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

            return new Topic
            {
                Name = name,
                Description = description
            };
        }
    }
}
