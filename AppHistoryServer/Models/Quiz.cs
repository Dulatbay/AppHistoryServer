using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Models
{
    public class Quiz : IModelId
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Number { get; set; }
        public User Author { get; set; } = null!;
        public int AuthorId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Question>? Questions { get; set; }

        // FavoritedUserQuizzes
        public ICollection<User>? AddedFavoritedUsers { get; set; }

        public ICollection<PassedUserQuizzes>? PassedUserQuizzes { get; set; }
    }
}
