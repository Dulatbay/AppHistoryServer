using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IQuestionService : IGetterService<QuestionDto>, 
                                        ICreatorService<QuestionDto, QuestionPostDto>, 
                                        IUpdaterService<QuestionDto, QuestionPostDto>, 
                                        IDeletorService<QuestionDto>
    {
    }
}
