using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;

namespace AppHistoryServer.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsersAsync();

        public async Task<User?> GetUserByEmail(string email) => await _userRepository.GetUserByEmailAsync(email);

        public async Task<User?> GetUserById(int id) => await _userRepository.GetUserByIdAsync(id);
    }
}
