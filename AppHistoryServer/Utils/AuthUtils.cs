using AppHistoryServer.Dtos;
using AppHistoryServer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppHistoryServer.Utils
{
    public class AuthUtils
    {
        private IConfiguration _configuration;

        public AuthUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GetToken(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("userName", user.UserName),
                    new Claim("email", user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var key = _configuration["JWT:Secret"];

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:ValidIssuer"],
                //audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        public bool VerifyLoginDto(User? user, string enteredPassword)
        {
            if (user?.UserName == null|| !this.VerifyPassword(enteredPassword, user.Password))
            {
                return false;
            }
            return true;
        }

        public bool VerifyRegisterDto(RegisterDto registerDto)
        {
            if (registerDto != null
              && this.IsEmail(registerDto.Email)
              && this.IsPassword(registerDto.Password)
              && this.IsUserName(registerDto.UserName))
            {
                return true;
            }
            return false;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        private bool IsPassword(string password)
        {
            if (password.Length < 3) return false;
            return true;
        }

        private bool IsEmail(string email)
        {
            if (!email.Contains("@")) return false;
            return true;
        }
        private bool IsUserName(string userName)
        {
            if (userName.Length < 3) return false;
            return true;
        }

    }
}
