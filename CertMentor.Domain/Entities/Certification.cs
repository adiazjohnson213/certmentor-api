namespace CertMentor.Domain.Entities
{
    public class Certification
    {
        private readonly List<SkillArea> _skillAreas = new();
        public IReadOnlyCollection<SkillArea> SkillAreas => _skillAreas.AsReadOnly();
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;

        private Certification()
        {
        }

        public static Certification Create(string code, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

            return new Certification
            {
                Code = code,
                Name = name
            };
        }
    }
}
