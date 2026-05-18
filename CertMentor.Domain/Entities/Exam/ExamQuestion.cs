using CertMentor.Domain.Entities.Catalog;
using CertMentor.Domain.Enums;

namespace CertMentor.Domain.Entities.Exam
{
    public class ExamQuestion
    {
        private readonly List<string> _answers = new();
        public IReadOnlyCollection<string> Answers => _answers.AsReadOnly();

        private readonly List<string> _correctAnswers = new();
        public IReadOnlyCollection<string> CorrectAnswers => _correctAnswers.AsReadOnly();
        public int Id { get; private set; }
        public string Question { get; private set; } = string.Empty;
        public QuestionType Type { get; private set; }
        public int ExamSessionId { get; private set; }
        public ExamSession ExamSession { get; private set; } = null!;
        public int TopicId { get; private set; }
        public Topic Topic { get; private set; } = null!;

        private ExamQuestion()
        {
        }

        public static ExamQuestion Create(string question,
                                          QuestionType type,
                                          int examSessionId,
                                          int topicId,
                                          IEnumerable<string> answers,
                                          IEnumerable<string> correctAnswers)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(question, nameof(question));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(examSessionId, 0, nameof(examSessionId));
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(topicId, 0, nameof(topicId));
            ArgumentNullException.ThrowIfNull(answers, nameof(answers));
            ArgumentNullException.ThrowIfNull(correctAnswers, nameof(correctAnswers));

            if (!answers.Any())
                throw new ArgumentException("A question must have at least one answer.", nameof(answers));

            if (!correctAnswers.Any())
                throw new ArgumentException("A question must have at least one correct answer.", nameof(correctAnswers));

            var examQuestion = new ExamQuestion
            {
                Question = question,
                Type = type,
                ExamSessionId = examSessionId,
                TopicId = topicId,
            };

            foreach (var answer in answers)
            {
                if (!string.IsNullOrWhiteSpace(answer))
                {
                    examQuestion._answers.Add(answer);
                }
            }

            foreach (var correctAnswer in correctAnswers)
            {
                if (!string.IsNullOrWhiteSpace(correctAnswer))
                {
                    examQuestion._correctAnswers.Add(correctAnswer);
                }
            }

            return examQuestion;
        }
    }
}
