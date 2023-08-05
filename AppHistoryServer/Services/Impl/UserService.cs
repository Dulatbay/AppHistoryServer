using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;
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

        public IEnumerable<User> GetAll() => _userRepository.GetAll();

        public IGetterRepository<User> GetGetterRepository() => _userRepository;

        public async Task<User?> GetUserByEmail(string email) => await _userRepository.GetUserByEmailAsync(email);

        public async Task<User?> GetByIdAsync(int id) => await _userRepository.GetByIdAsync(id);

    }
}
