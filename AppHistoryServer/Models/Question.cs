using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Dtos.ContentDtos.Variant;

namespace AppHistoryServer.Models
{
    public class Question
    {
        public int Id { get; set; }
        
        public string QuestionText { get; set; } = null!;

        // Variants can be ImageQuestion or TextQuestion
        public ICollection<Variant> Variants { get; set; } = null!;

        public int CorrectVarianIndex { get; set; }
        
        public Topic Topic { get; set; } = null!;
        
        public User Author { get; set; } = null!;

        // the question may be in some test
        public ArchiveBook? ArchiveBook { get; set; } = null!;

        public ICollection<Quiz>? Quizzes { get; set; }
        public ICollection<PassedUserQuestions>? PassedUserQuestions { get; set; }
        
    }
}
