using AppHistoryServer.Models.Interfaces;
using Newtonsoft.Json;

namespace AppHistoryServer.Models
{
    public class Quiz : IModelId
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        
        [JsonIgnore]
        public User Author { get; set; } = null!;
        public int AuthorId { get; set; }
        public bool IsVerified { get; set; }
        public int Level { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Question>? Questions { get; set; }
        
        [JsonIgnore]
        public ICollection<User>? AddedFavoritedUsers { get; set; }
        
        [JsonIgnore]
        public ICollection<PassedUserQuizzes>? PassedUserQuizzes { get; set; }
    }
}
