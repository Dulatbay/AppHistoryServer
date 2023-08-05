using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Services.BaseInterfaces;

namespace AppHistoryServer.Services.Interfaces
{
    public interface IQuestionService : IGetterService<Question>
    {
        public Task<Question> CreateAsync(QuestionPostDto questionPostDto);
        public Task<Question> UpdateAsync(int id, QuestionPostDto questionPostDto);
        public Task<Question> DeleteAsync(int id);
    }
}
