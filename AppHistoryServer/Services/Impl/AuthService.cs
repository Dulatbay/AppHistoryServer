﻿using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using AppHistoryServer.Utils;
using AppHistoryServer.Dtos.AuthDtos;
using AppHistoryServer.Dtos.UserDtos;

namespace AppHistoryServer.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly AuthUtils _authUtils;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthService(IConfiguration configuration,
                           IUserRepository userRepository,
                           IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authUtils = new AuthUtils(_configuration);
            _contextAccessor = contextAccessor;
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {

            if (!_authUtils.VerifyRegisterDto(registerDto))
                throw new BadHttpRequestException("Не корректные данные");

            var user = await _userRepository.GetUserByEmailAsync(registerDto.Email);

            if (user != null)
                throw new BadHttpRequestException("Такой логин уже существует");

            registerDto.Password = _authUtils.HashPassword(registerDto.Password);

            user = await _userRepository.SaveAsync(User.GetUserByRegisterDto(registerDto));

            var token = _authUtils.GetToken(user);

            return new AuthResponseDto(token, new UserDto(user));
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !_authUtils.VerifyLoginDto(user, loginDto.Password))
                throw new BadHttpRequestException("Не корректные данные");

            var token = _authUtils.GetToken(user);

            return new AuthResponseDto(token, new UserDto(user));
        }

        public async Task<AuthResponseDto> GetMe()
        {
            var token = AuthUtils.GetTokenFromHeader(_contextAccessor);

            if (token == null)
                throw new UnauthorizedAccessException();

            var user = _authUtils.GetUserFromToken(token);

            if (user == null)
                throw new UnauthorizedAccessException();

            var currentUser = await _userRepository.GetByIdAsync(user.Id);

            if (currentUser == null)
                throw new UnauthorizedAccessException();

            return new AuthResponseDto(new JwtSecurityToken(token), new UserDto(currentUser));
        }
    }
}
