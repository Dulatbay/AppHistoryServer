using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.AuthDtos
{
    public class RegisterDto : IDtoModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; } 
        public string? Password { get; set; } 
    }
}
