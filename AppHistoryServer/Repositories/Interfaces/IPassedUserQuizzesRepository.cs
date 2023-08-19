using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IPassedUserQuizzesRepository : ISaverRepository<PassedUserQuizzes>
    {
    }
}
