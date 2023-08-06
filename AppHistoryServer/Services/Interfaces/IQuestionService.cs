using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IQuestionService : IGetterService<Question>, 
                                        ICreatorService<Question,QuestionPostDto>, 
                                        IUpdaterService<Question, QuestionPostDto>, 
                                        IDeletorService<Question>
    {

    }
}
