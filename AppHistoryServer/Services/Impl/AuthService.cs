using AppHistoryServer.Dtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using AppHistoryServer.Utils;

namespace AppHistoryServer.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly AuthUtils _authUtils;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authUtils = new AuthUtils(_configuration);
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(registerDto.Email);

            if (user != null)
                throw new BadHttpRequestException("Такой логин уже существует");

            if (!_authUtils.VerifyRegisterDto(registerDto))
                throw new BadHttpRequestException("Не корректные данные");

            registerDto.Password = _authUtils.HashPassword(registerDto.Password);

            user = await _userRepository.Save(User.GetUserByRegisterDto(registerDto));

            var token = _authUtils.GetToken(user);

            return new AuthResponseDto(token);
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (!_authUtils.VerifyLoginDto(user, loginDto.Password))
                throw new BadHttpRequestException("Не корректные данные");
          
            var token = _authUtils.GetToken(user);

            return new AuthResponseDto(token);
        }

    }
}
