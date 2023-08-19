using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IUserService : IGetterService<UserDto>
    {
        public Task<UserDto?> GetUserByEmailAsync(string email);
        public Task<object> GetMeShockDaysAsync();
        public Task<UserCardDto> GetUserCardByIdAsync(int id);
    }
}
