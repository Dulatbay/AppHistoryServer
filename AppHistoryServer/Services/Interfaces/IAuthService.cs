using AppHistoryServer.Dtos;
using AppHistoryServer.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponseDto> Register(RegisterDto registerDto);

        public Task<AuthResponseDto> Login(LoginDto loginDto);
        public Task<AuthResponseDto> GetMe();
    }
}
