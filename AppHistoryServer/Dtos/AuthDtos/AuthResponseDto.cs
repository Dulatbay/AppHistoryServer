using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;

namespace AppHistoryServer.Dtos.AuthDtos
{
    public class AuthResponseDto : IDtoModel
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
