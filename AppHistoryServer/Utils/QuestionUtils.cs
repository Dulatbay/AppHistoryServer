using AppHistoryServer.Models.Variant;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Repositories.Impl;
using AppHistoryServer.Dtos.UserDtos;

namespace AppHistoryServer.Utils
{
    public static class QuestionUtils
    {
        public static async Task SetVariants(Question question, IVariantRepository variantRepository)
        {
            var resultVariants = new List<Variant>();
            foreach (var variant in question.Variants)
            {
                if (variant == null) continue;

                var existVariant = await variantRepository.GetByIdAsync(variant.Id);

                if (existVariant == null)
                    existVariant = await variantRepository.SaveAsync(variant);

                resultVariants.Add(existVariant);
            }

            question.Variants = resultVariants;
        }

        public static async Task<Question> CheckModelAsync(IQuestionRepository questionRepository,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            IUserRepository userRepository,
            ITopicRepository topicRepository,
            QuestionPostDto questionPostDto,
            int toUpdateModelId)
        {
            var existingQuestion = await questionRepository.GetByIdAsync(toUpdateModelId);
            if (existingQuestion == null)
                throw new BadHttpRequestException("Question with this Id not found.");

            string? token = AuthUtils.GetTokenFromHeader(httpContextAccessor);

            if (token == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            UserDto? userDto = new AuthUtils(configuration).GetUserFromToken(token);

            if (userDto == null || userDto.Id != existingQuestion.Id)
                throw new UnauthorizedAccessException("Нет доступа.");

            User? author = await userRepository.GetByIdAsync(userDto.Id);
            if (author == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            Topic? topic = await topicRepository.GetByIdAsync(questionPostDto.TopicId);
            if (topic == null)
                throw new BadHttpRequestException("Вопрос должен принадлежать какой-то теме!");

            if (questionPostDto.QuestionText == null)
                throw new BadHttpRequestException("Введите вопрос!");
            if (questionPostDto.Variants == null)
                throw new BadHttpRequestException("Введите варианты!");
            if (questionPostDto.CorrectVariantIndex <= questionPostDto.Variants.Count)
                throw new BadHttpRequestException("Индекс правильного ответа не должен превышать количество вариантов!");

         
            return existingQuestion;
        }
    }
}
