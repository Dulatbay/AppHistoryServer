using AppHistoryServer.Models;

namespace AppHistoryServer.Utils.Initializer
{
    public static class QuizInitializer
    {
        public static void Init(ApplicationDbContext context)
        {
            Quiz quiz = new Quiz()
            {
                AuthorId = 1,
                Title = "Тест 1",
                Level = new Random().Next(1, 4),
                Questions = context.Questions.ToList(),
            };
            context.Quizzes.Add(quiz);
            context.SaveChanges();
        }
    }
}
