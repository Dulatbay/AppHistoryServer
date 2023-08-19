using AppHistoryServer.Models.Interfaces;
using Newtonsoft.Json;

namespace AppHistoryServer.Models
{
    public class Quiz : IModelId
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        
        public User? Author { get; set; }
        public int AuthorId { get; set; }
        public bool IsVerified { get; set; }
        public int Level { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public IList<Question> Questions { get; set; } = new List<Question>();
        
        public ICollection<User> AddedFavoritedUsers { get; set; } = new List<User>();
        
        public ICollection<PassedUserQuizzes> PassedUserQuizzes { get; set; } = new List<PassedUserQuizzes>();
    }
}
