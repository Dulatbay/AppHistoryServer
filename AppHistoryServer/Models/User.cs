using AppHistoryServer.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AppHistoryServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public int ShockDay { get; set; }

        public League League { get; set; }

        public DateTime LastPlay { get; set; }
        public string? ImageUrl { get; set; }
        public Topic? lastTopic { get; set; }

        public static User GetUserByRegisterDto(RegisterDto register)
        {
            return new User() { Email = register.Email, Password = register.Password, UserName = register.UserName };
        }
    }
}
