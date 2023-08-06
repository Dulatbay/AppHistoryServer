using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.AuthDtos
{
    public class RegisterDto : IDtoModel
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
