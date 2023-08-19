using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IQuizRepository : IGetterRepository<Quiz>,
                                       ISaverRepository<Quiz>,
                                       IDeleterRepository<Quiz>,
                                       IUpdaterRepository<Quiz>
    {
        public Task<ICollection<Quiz>> GetQuizzesByFilterAsync(QuizType type, QuizCategory category, UserDto user);
    }
}
