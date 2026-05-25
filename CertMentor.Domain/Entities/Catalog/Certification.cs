namespace CertMentor.Domain.Entities.Catalog
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

        public void AddSkillArea(SkillArea skillArea)
        {
            ArgumentNullException.ThrowIfNull(skillArea, nameof(skillArea));
            if (_skillAreas.Any(sa => sa.Name.Equals(skillArea.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Skill area with name '{skillArea.Name}' already exists for this certification.");
            }
            _skillAreas.Add(skillArea);
        }

        public void Update(string name, IReadOnlyCollection<string> skillAreas)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
            foreach (var existing in _skillAreas)
            {
                if (!skillAreas.Any(sa => sa.Equals(existing.Name, StringComparison.OrdinalIgnoreCase)))
                    existing.Deactivate();
            }

            foreach (var skillArea in skillAreas)
            {
                if (!_skillAreas.Any(sa => sa.Name.Equals(skillArea, StringComparison.OrdinalIgnoreCase)))
                    _skillAreas.Add(SkillArea.Create(skillArea));
            }
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
