using CertMentor.Domain.Enums;

namespace CertMentor.Domain.Entities.Exam
{
    public class UserAnswer
    {
        private readonly List<string> _answers = new();
        public IReadOnlyCollection<string> Answers => _answers.AsReadOnly();
        public int Id { get; private set; }
        public bool IsCorrect { get; private set; } = false;
        public int ExamQuestionId { get; private set; }
        public ExamQuestion ExamQuestion { get; private set; } = null!;

        private UserAnswer()
        {
        }
        public static UserAnswer Create(int examQuestionId, IEnumerable<string> answers)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(examQuestionId, 0, nameof(examQuestionId));
            ArgumentNullException.ThrowIfNull(answers, nameof(answers));

            if (!answers.Any())
                throw new ArgumentException("A question must have at least one answer.", nameof(answers));

            var userAnswer = new UserAnswer
            {
                ExamQuestionId = examQuestionId
            };

            foreach (var answer in answers)
            {
                if (!string.IsNullOrWhiteSpace(answer))
                {
                    userAnswer._answers.Add(answer);
                }
            }
            return userAnswer;
        }

        public void Evaluate(QuestionType questionType, IEnumerable<string> correctAnswers)
        {
            if (questionType == QuestionType.Ordering)
            {
                IsCorrect = _answers.SequenceEqual(correctAnswers);
            }
            else
            {
                var userAnswersSet = new HashSet<string>(_answers);
                var correctAnswersSet = new HashSet<string>(correctAnswers);
                IsCorrect = userAnswersSet.SetEquals(correctAnswersSet);
            }
        }

    }
}
