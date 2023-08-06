using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.QuizDtos
{
    public class QuizGeneratePostDto : IDtoModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }
    }
}
