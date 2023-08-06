using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IQuizService : IGetterService<Quiz>,
                                    ICreatorService<Quiz, QuizPostDto>,
                                    IUpdaterService<Quiz, QuizPostDto>,
                                    IDeletorService<Quiz>
    {
        public Task<Quiz> GenerateQuizAsync(QuizGeneratePostDto quizGeneratePostDto, ICollection<int> topicsId, int questionsCount = 5);
    }
}
