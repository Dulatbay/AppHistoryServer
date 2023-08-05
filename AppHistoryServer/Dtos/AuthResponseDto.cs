using System.IdentityModel.Tokens.Jwt;

namespace AppHistoryServer.Dtos
{
    public class AuthResponseDto
    {
        public string? Token { get; set; }
        public UserDto User { get; set; }

        public AuthResponseDto(JwtSecurityToken token, UserDto user)
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token);
            User = user;
        }
    }
}
