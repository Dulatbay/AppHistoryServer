using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class PassedUserQuizzes : IModelId
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;
        public ICollection<PassedUserQuestions> PassedQuestions { get; set;} = new HashSet<PassedUserQuestions>();
    }
}
