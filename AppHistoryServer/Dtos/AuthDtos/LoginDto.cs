using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.AuthDtos
{
    public class LoginDto : IDtoModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
