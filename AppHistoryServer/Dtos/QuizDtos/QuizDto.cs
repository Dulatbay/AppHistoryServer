using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizDto : IDtoModel
    {
        public int Id { get; set; }
        public float UserPercent { get; set; }
        public int PassedUsersCount { get; set; }
        public int QuestionsCount { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
