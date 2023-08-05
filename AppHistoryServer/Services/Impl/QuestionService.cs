using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using AppHistoryServer.Utils;

namespace AppHistoryServer.Services.Impl
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IVariantRepository _variantRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ITopicRepository _topicRepository;
        private readonly IArchiveBookRepository _archiveBookRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IUserRepository _userRepository;

        public QuestionService(IQuestionRepository questionRepository,
                               IVariantRepository variantRepository,
                               IHttpContextAccessor contextAccessor,
                               IConfiguration configuration,
                               ITopicRepository topicRepository,
                               IArchiveBookRepository archiveBookRepository,
                               IQuizRepository quizRepository,
                               IUserRepository userRepository)
        {
            _questionRepository = questionRepository;
            _variantRepository = variantRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _topicRepository = topicRepository;
            _archiveBookRepository = archiveBookRepository;
            _quizRepository = quizRepository;
            _userRepository = userRepository;
        }

        private async Task SetVariants(Question question)
        {
            var resultVariants = new List<Variant>();
            foreach (var variant in question.Variants)
            {
                if (variant == null) continue;

                var existVariant = await _variantRepository.GetByIdAsync(variant.Id);

                if (existVariant == null)
                {
                    existVariant = await _variantRepository.SaveAsync(variant);
                }

                resultVariants.Add(existVariant);
            }

            question.Variants = resultVariants;
        }

        public async Task<Question> CreateAsync(QuestionPostDto questionPostDto)
        {
            string? token = AuthUtils.GetTokenFromHeader(_contextAccessor);

            if (token == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            UserDto? userDto = new AuthUtils(_configuration).GetUserFromToken(token);

            if (userDto == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            User? author = await _userRepository.GetByIdAsync(userDto.Id);
            if (author == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            Topic? topic = await _topicRepository.GetByIdAsync(questionPostDto.TopicId);
            if (topic == null)
                throw new BadHttpRequestException("Вопрос должен принадлежать какой-то теме!");

            ArchiveBook? archiveBook = await _archiveBookRepository.GetByIdAsync(questionPostDto.ArchiveBookId);
            Quiz? quiz = await _quizRepository.GetByIdAsync(questionPostDto.QuizId);



            Question question = new Question(questionPostDto, author, topic, archiveBook, quiz);

            await this.SetVariants(question);

            var savedQuestion = await _questionRepository.SaveAsync(question);

            return savedQuestion;
        }

        public async Task<Question> DeleteAsync(int id)
        {
            var toRemove = await _questionRepository.GetByIdAsync(id);
            if (toRemove == null)
                throw new BadHttpRequestException("Question with this Id not found.");

            var removed = await _questionRepository.DeleteAsync(toRemove);
            return removed;
        }

        public IEnumerable<Question> GetAll() => _questionRepository.GetAll();

        public Task<Question?> GetByIdAsync(int id) => _questionRepository.GetByIdAsync(id);

        public async Task<Question> UpdateAsync(int id, QuestionPostDto questionPostDto)
        {
            var existingQuestion = await _questionRepository.GetByIdAsync(id);
            if (existingQuestion == null)
                throw new BadHttpRequestException("Question with this Id not found.");

            string? token = AuthUtils.GetTokenFromHeader(_contextAccessor);

            if (token == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            UserDto? userDto = new AuthUtils(_configuration).GetUserFromToken(token);

            if (userDto == null || userDto.Id != existingQuestion.Id)
                throw new UnauthorizedAccessException("Нет доступа.");

            User? author = await _userRepository.GetByIdAsync(userDto.Id);
            if (author == null)
                throw new UnauthorizedAccessException("Нет доступа.");

            Topic? topic = await _topicRepository.GetByIdAsync(questionPostDto.TopicId);
            if (topic == null)
                throw new BadHttpRequestException("Вопрос должен принадлежать какой-то теме!");

            ArchiveBook? archiveBook = await _archiveBookRepository.GetByIdAsync(questionPostDto.ArchiveBookId);
            Quiz? quiz = await _quizRepository.GetByIdAsync(questionPostDto.QuizId);



            Question question = new Question(questionPostDto, author, topic, archiveBook, quiz);



            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.ArchiveBook = question.ArchiveBook;
            existingQuestion.Topic = question.Topic;
            existingQuestion.CorrectVarianIndex = question.CorrectVarianIndex;
            existingQuestion.Variants = question.Variants;

            await this.SetVariants(existingQuestion);

            return (await _questionRepository.UpdateAsync(existingQuestion));
        }
    }
}
