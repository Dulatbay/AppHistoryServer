using System.IdentityModel.Tokens.Jwt;

namespace AppHistoryServer.Dtos
{
    public class AuthResponseDto
    {
        public string? Token { get; set; }

        public AuthResponseDto(JwtSecurityToken token)
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
