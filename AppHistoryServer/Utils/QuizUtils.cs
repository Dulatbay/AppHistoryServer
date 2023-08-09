using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.Interfaces;

namespace AppHistoryServer.Utils
{
    public static class QuizUtils
    {
        public static void CheckModel(QuizPostDto model)
        {
            if (model.Questions == null || model.Questions.Count < 2)
                throw new BadHttpRequestException("Квиз должен содержать минимум 2 вопроса.");

            if (model.Title == null)
                throw new BadHttpRequestException("Квиз должен содержать тему.");
            if (model.Description == null)
                throw new BadHttpRequestException("Квиз должен содержать описание.");
        }

        public static async Task<ICollection<Question>> SetQuestionsAsync(QuizPostDto quizPostDto, IQuestionRepository questionRepository, IVariantRepository variantRepository, User author, ITopicRepository topicRepository)
        {
            var resultQuestions = new List<Question>();

            if (quizPostDto.Questions == null)
                throw new ArgumentNullException(nameof(quizPostDto.Questions));

            foreach (var question in quizPostDto.Questions)
            {
                if (question == null) continue;

                var existQuestion = await questionRepository.GetByIdAsync(question.Id);

                if (existQuestion == null)
                {
                    question.Author = author;
                    question.Topic = await topicRepository.GetByIdAsync(question.TopicId);

                    await QuestionUtils.SetVariants(question, variantRepository);

                    existQuestion = await questionRepository.SaveAsync(question);
                }

                resultQuestions.Add(existQuestion);
            }

            return resultQuestions;
        }
    }
}
