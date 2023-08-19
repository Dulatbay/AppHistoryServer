using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class PassedUserQuestions : IModelId
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public int ChooseIndex { get; set; }
        public ICollection<PassedUserQuizzes> PassedUserQuizzes { get; set; } = new List<PassedUserQuizzes>();
    }
}
