using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IQuizService : IGetterService<QuizDto>,
                                    ICreatorService<QuizDto, QuizPostDto>,
                                    IUpdaterService<QuizDto, QuizPostDto>,
                                    IDeletorService<QuizDto>,
                                    IGetterDetail<QuizDetailDto>
    {
        public Task<QuizDto> GenerateQuizAsync(QuizGeneratePostDto quizGeneratePostDto, ICollection<int> topicsId, int questionsCount = 5);
        public Task ChangeImage(int id, IFormFile file);
        public Task<ICollection<QuizDto>> GetByFilterAsync(string type, string category);
        public Task<QuizDetailDto> PassQuizAsync(QuizPassedDto quizPassedDto);
    }
}
