using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;

namespace AppHistoryServer.Utils
{
    public static class QuizUtils
    {
        public static void CheckModel(QuizPostDto model)
        {
            if (model.Questions == null || model.Questions.Count < 5)
                throw new BadHttpRequestException("Квиз должен содержать минимум 5 вопросов.");

            if (model.Title == null)
                throw new BadHttpRequestException("Квиз должен содержать тему.");
            if (model.Description == null)
                throw new BadHttpRequestException("Квиз должен содержать описание.");
        
        }
    }
}
