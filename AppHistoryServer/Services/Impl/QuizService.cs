using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Impl;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using AppHistoryServer.Utils;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging;

namespace AppHistoryServer.Services.Impl
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IVariantRepository _variantRepository;
        private readonly ITopicRepository _topicRepository;
        public QuizService(IQuizRepository quizRepository,
                           IHttpContextAccessor contextAccessor,
                           IConfiguration configuration,
                           IUserRepository userRepository,
                           IQuestionRepository questionRepository,
                           IVariantRepository variantRepository,
                           ITopicRepository topicRepository)
        {
            _quizRepository = quizRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _variantRepository = variantRepository;
            _topicRepository = topicRepository;
        }

        public async Task<Quiz> CreateAsync(QuizPostDto model)
        {
            QuizUtils.CheckModel(model);
            
            User user = await new AuthUtils(_configuration).GetMeUserAsync(_contextAccessor, _userRepository);


            Quiz quiz = new Quiz()
            {
                Title = model.Title,
                Description = model.Description,
                Level = model.Level,
                AuthorId = user.Id,
                IsVerified = false
            };

            quiz.Questions = await QuizUtils.SetQuestionsAsync(model, _questionRepository, _variantRepository, user,_topicRepository);
            
            return await _quizRepository.SaveAsync(quiz);
        }

        public async Task<Quiz> DeleteAsync(int id)
        {
            var toRemove = await _quizRepository.GetByIdAsync(id);
            if (toRemove == null)
                throw new BadHttpRequestException("Quiz with this Id not found.");

            var removed = await _quizRepository.DeleteAsync(toRemove);
            return removed;
        }

        public async Task<Quiz> GenerateQuizAsync(QuizGeneratePostDto quizGeneratePostDto, ICollection<int> topicsId, int questionsCount = 5)
        {
            User user = await new AuthUtils(_configuration).GetMeUserAsync(_contextAccessor, _userRepository);

            if (quizGeneratePostDto.Title == null)
                throw new BadHttpRequestException($"Квиз должен содержать тему.");

            if (quizGeneratePostDto.Description == null)
                throw new BadHttpRequestException($"Квиз должен содержать описание.");

            ICollection<Question> questions = new HashSet<Question>();
            foreach (var topicId in topicsId)
            {
                questions.AddRange(await _questionRepository.GetQuestionsByTopicIdAsync(topicId, quizGeneratePostDto.Level));
            }

            if (questions.Count == 0)
                throw new BadHttpRequestException($"Не удалось найти вопросы по заданным параметрам.");
            else if (questions.Count > questionsCount)
                throw new BadHttpRequestException($"Слишком большое количество вопросов. Изменить настройки квиза или снизьте количество вопросов до {questions.Count}");


            questions = questions.OrderBy(q => Guid.NewGuid()).ToList().Take(questionsCount).ToList();

            Quiz quiz = new Quiz();
            quiz.AuthorId = user.Id;
            quiz.Description = quizGeneratePostDto.Description;
            quiz.Title = quizGeneratePostDto.Title;
            quiz.Level = quizGeneratePostDto.Level;
            quiz.IsVerified = false;
            quiz.Questions = questions;

            quiz = await _quizRepository.SaveAsync(quiz);

            return quiz;
        }



        public IEnumerable<Quiz> GetAll()
        {
            return _quizRepository.GetAll();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task<Quiz> UpdateAsync(int id, QuizPostDto model)
        {
            User user = await new AuthUtils(_configuration).GetMeUserAsync(_contextAccessor, _userRepository);

            var existingQuiz = await _quizRepository.GetByIdAsync(id);

            if (existingQuiz == null)
                throw new BadHttpRequestException("Квиз не найден.");

            if (existingQuiz.AuthorId != user.Id)
                throw new UnauthorizedAccessException("Квиз не принадлежит пользователю.");

            QuizUtils.CheckModel(model);



            existingQuiz.AuthorId = user.Id;
            existingQuiz.IsVerified = model.IsVerified ?? existingQuiz.IsVerified;
            existingQuiz.Description = model.Description;
            existingQuiz.Title = model.Title ?? "";
            existingQuiz.Level = model.Level;


            foreach (var question in model.Questions)
            {
                await QuestionUtils.SetVariants(question, _variantRepository);

                var existQuestion = await _questionRepository.GetByIdAsync(question.Id);

                if (existQuestion == null)
                    await _questionRepository.SaveAsync(question);
            }

            existingQuiz.Questions = model.Questions;

            return await _quizRepository.UpdateAsync(existingQuiz);
        }
    }
}
