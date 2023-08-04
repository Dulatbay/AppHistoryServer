namespace AppHistoryServer.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Number { get; set; }
        public User Author { get; set; } = null!;
        public bool IsVerified { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Question>? Questions { get; set; }

        // FavoritedUserQuizzes
        public ICollection<User>? AddedFavoritedUsers { get; set; }

        public ICollection<PassedUserQuizzes>? PassedUserQuizzes { get; set; }
    }
}
