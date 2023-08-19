using AppHistoryServer.Dtos;
using AppHistoryServer.Dtos.QuestionDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.BaseInterfaces;
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



        public async Task<QuestionDto> CreateAsync(QuestionPostDto questionPostDto)
        {
            User author = await new AuthUtils(_configuration).GetMeRequiredUserAsync(_contextAccessor, _userRepository);

            Topic? topic = await _topicRepository.GetByIdAsync(questionPostDto.TopicId);
            if (topic == null)
                throw new BadHttpRequestException("Вопрос должен принадлежать какой-то теме!");

            ArchiveBook? archiveBook = await _archiveBookRepository.GetByIdAsync(questionPostDto.ArchiveBookId);
            Quiz? quiz = await _quizRepository.GetByIdAsync(questionPostDto.QuizId);



            Question question = new Question(questionPostDto, author, topic, archiveBook, quiz);

            await QuestionUtils.SetVariants(question, _variantRepository);

            var savedQuestion = await _questionRepository.SaveAsync(question);

            return new QuestionDto(savedQuestion);
        }

        public async Task<QuestionDto> DeleteAsync(int id)
        {
            var toRemove = await _questionRepository.GetByIdAsync(id);
            if (toRemove == null)
                throw new BadHttpRequestException("Question with this Id not found.");

            var removed = await _questionRepository.DeleteAsync(toRemove);
            return new QuestionDto(removed);
        }

        public IEnumerable<QuestionDto> GetAll() => QuestionDto.GetAll(_questionRepository.GetAll());

        public async Task<QuestionDto?> GetByIdAsync(int id) => new QuestionDto(await _questionRepository.GetByIdAsync(id));

        public async Task<QuestionDto> UpdateAsync(int id, QuestionPostDto questionPostDto)
        {
            var existingQuestion = await QuestionUtils.CheckModelAsync(_questionRepository,
                _contextAccessor,
                _configuration,
                _userRepository,
                _topicRepository,
                questionPostDto,
                id);
            ArchiveBook? archiveBook = await _archiveBookRepository.GetByIdAsync(questionPostDto.ArchiveBookId);

            Quiz? quiz = await _quizRepository.GetByIdAsync(questionPostDto.QuizId);

            Topic? topic = await _topicRepository.GetByIdAsync(questionPostDto.TopicId);

            existingQuestion.QuestionText = questionPostDto.QuestionText;
            existingQuestion.ArchiveBook = archiveBook;
            if (topic != null)
                existingQuestion.Topic = topic;
            if (quiz != null)
            {
                if(existingQuestion.Quizzes==null) existingQuestion.Quizzes = new List<Quiz>();
                existingQuestion.Quizzes.Add(quiz);
            }
            existingQuestion.CorrectVarianIndex = questionPostDto.CorrectVariantIndex;
            existingQuestion.Variants = questionPostDto.Variants;
            existingQuestion.Level = questionPostDto.Level;

            await QuestionUtils.SetVariants(existingQuestion, _variantRepository);

            return new QuestionDto(await _questionRepository.UpdateAsync(existingQuestion));
        }
    }
}
