using AppHistoryServer.Dtos;

namespace AppHistoryServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int ShockDay { get; set; }

        public League League { get; set; }

        public DateTime LastPlay { get; set; }
        public string? ImageUrl { get; set; }
        public Topic? lastTopic { get; set; }


        public ICollection<Question>? CreatedQuestions { get; set; }
        public ICollection<Quiz>? CreatedQuizzes{ get; set; }
        public ICollection<Quiz>? FavoritedQuizzes{ get; set; } 
        public ICollection<PassedUserTopics>? PassedUserTopics{ get; set; } 
        public ICollection<PassedUserQuestions>? PassedUserQuestions{ get; set; } 
        public ICollection<PassedUserQuizzes>? PassedUserQuizzes{ get; set; } 


        public static User GetUserByRegisterDto(RegisterDto register)
        {
            return new User() { Email = register.Email, Password = register.Password, UserName = register.UserName };
        }
    }
}
