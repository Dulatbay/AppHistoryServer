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
        public UserDto? GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecret = _configuration["JWT:Secret"];

            if (jwtSecret == null) throw new ArgumentNullException(nameof(jwtSecret));

            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };

            var claimsPrincipal = handler.ValidateToken(token, validationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            var userId = claimsPrincipal.FindFirstValue("id");
            var userName = claimsPrincipal.FindFirstValue("userName");
            var email = claimsPrincipal.FindFirstValue("email");

            if (userId != null && userName != null && email != null)
            {

                var user = new User
                {
                    Id = int.Parse(userId),
                    UserName = userName,
                    Email = email
                };

                var userDto = new UserDto(user);

                return userDto;
            }
            return null;
        }

        public bool VerifyLoginDto(User? user, string enteredPassword)
        {
            if (user?.UserName == null || !this.VerifyPassword(enteredPassword, user.Password))
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
        public static string? GetTokenFromHeader(IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext;
            if (context == null)
            {
                // TODO: Обработать
                return null;
            }

            if (context.Request.Headers.TryGetValue("Authorization", out var authHeaderValue))
            {
                string authorizationValue = authHeaderValue.ToString();
                return authorizationValue;
            }
            return null;
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
