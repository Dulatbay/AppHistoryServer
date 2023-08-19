using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Utils;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizDto : IDtoModel
    {
        public int Id { get; set; }
        public float UserPercent { get; set; }
        public int PassedUsersCount { get; set; }
        public int QuestionsCount { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public bool IsVerified { get; set; }
        public int Level { get; set; }
        public QuizDto(Quiz? quiz)
        {
            if (quiz == null) throw new ArgumentNullException(nameof(quiz));
            if (quiz.Questions == null) throw new ArgumentNullException(nameof(quiz.Questions));

            Id = quiz.Id;
            Title = quiz.Title;
            QuestionsCount = quiz.Questions.Count;
            if (quiz.ImageUrl != null)
                ImageUrl = "https://localhost:7279/api/" + quiz.ImageUrl;
            PassedUsersCount = quiz.PassedUserQuizzes.Count;
            Level = quiz.Level;
            IsVerified = quiz.IsVerified;
            UserPercent = QuizUtils.GetAverageResult(quiz);
        }

        public static IEnumerable<QuizDto> GetAll(IEnumerable<Quiz>? quizzes)
        {
            if (quizzes == null)
                yield break;

            foreach (var quiz in quizzes)
            {
                yield return new QuizDto(quiz);
            }
        }
    }
}
