using AppHistoryServer.Dtos.QuizDtos;
using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using AppHistoryServer.Utils;
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
        private readonly IFileService _fileService;
        private readonly IPassedUserQuestionsRepository _passedUserQuestionsRepository;
        private readonly IPassedUserQuizzesRepository _passedUserQuizzesRepository;
        private readonly AuthUtils _authUtils;
        public QuizService(IQuizRepository quizRepository,
                           IHttpContextAccessor contextAccessor,
                           IConfiguration configuration,
                           IUserRepository userRepository,
                           IQuestionRepository questionRepository,
                           IVariantRepository variantRepository,
                           ITopicRepository topicRepository,
                           IFileService fileService,
                           IPassedUserQuizzesRepository passedUserQuizzesRepository,
                           IPassedUserQuestionsRepository passedUserQuestionsRepository)
        {
            _quizRepository = quizRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _variantRepository = variantRepository;
            _topicRepository = topicRepository;
            _fileService = fileService;
            _authUtils = new AuthUtils(_configuration);
            _passedUserQuizzesRepository = passedUserQuizzesRepository;
            _passedUserQuestionsRepository = passedUserQuestionsRepository;
        }

        public async Task ChangeImage(int id, IFormFile file)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null) throw new BadHttpRequestException("Не найден квиз");

            var newPath = await _fileService.ChangeFileAsync(file, quiz.ImageUrl);
            quiz.ImageUrl = newPath;
            await _quizRepository.UpdateAsync(quiz);
        }

        public async Task<QuizDto> CreateAsync(QuizPostDto model)
        {
            QuizUtils.CheckModel(model);

            User user = await _authUtils.GetMeRequiredUserAsync(_contextAccessor, _userRepository);



            Quiz quiz = new Quiz()
            {
                Title = model.Title,
                Description = model.Description,
                Level = model.Level,
                AuthorId = user.Id,
                IsVerified = false
            };

            quiz.Questions = (await QuizUtils.SetQuestionsAsync(model, _questionRepository, _variantRepository, user, _topicRepository)).ToList();

            return new QuizDto(await _quizRepository.SaveAsync(quiz));
        }

        public async Task<QuizDto> DeleteAsync(int id)
        {
            var toRemove = await _quizRepository.GetByIdAsync(id);
            if (toRemove == null)
                throw new BadHttpRequestException("Quiz with this Id not found.");

            User user = await _authUtils.GetMeRequiredUserAsync(_contextAccessor, _userRepository);


            if (toRemove.AuthorId != user.Id)
                throw new BadHttpRequestException("Only author can delete quiz");


            var removed = await _quizRepository.DeleteAsync(toRemove);
            return new QuizDto(removed);
        }

        public async Task<QuizDto> GenerateQuizAsync(QuizGeneratePostDto quizGeneratePostDto, ICollection<int> topicsId, int questionsCount = 5)
        {
            User user = await _authUtils.GetMeRequiredUserAsync(_contextAccessor, _userRepository);

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
            quiz.Questions = questions.ToList();

            quiz = await _quizRepository.SaveAsync(quiz);

            return new QuizDto(quiz);
        }



        public IEnumerable<QuizDto> GetAll()
        {
            return QuizDto.GetAll(_quizRepository.GetAll());
        }

        public async Task<ICollection<QuizDto>> GetByFilterAsync(string type, string category)
        {
            QuizCategory quizCategory = QuizCategory.POPULAR;
            QuizType quizType = QuizType.ALL;

            switch (category.ToLower())
            {
                case "popular":
                    quizCategory = QuizCategory.POPULAR;
                    break;
                case "new":
                    quizCategory = QuizCategory.NEW;
                    break;
                case "top":
                    quizCategory = QuizCategory.TOP;
                    break;
                case "my":
                    quizCategory = QuizCategory.MY;
                    break;
            }

            switch (type.ToLower())
            {
                case "passed":
                    quizType = QuizType.PASSED;
                    break;
                case "all":
                    quizType = QuizType.ALL;
                    break;
                case "not-passed":
                    quizType = QuizType.NOT_PASSED;
                    break;
            }

            UserDto? user = null;
            string? token = AuthUtils.GetTokenFromHeader(_contextAccessor);
            if (token != null)
                user = _authUtils.GetUserFromToken(token);

            if (user == null)
                user = new UserDto(new User());

            var result = await _quizRepository.GetQuizzesByFilterAsync(quizType, quizCategory, user);
            return QuizDto.GetAll(result).ToList();
        }

        public async Task<QuizDto?> GetByIdAsync(int id)
        {
            return new QuizDto(await _quizRepository.GetByIdAsync(id));
        }

        public async Task<QuizDetailDto?> GetDetailByIdAsync(int id)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null) return null;
            quiz.Author = await _userRepository.GetByIdAsync(quiz.AuthorId);
            return new QuizDetailDto(quiz);
        }

        public async Task<QuizDetailDto> PassQuizAsync(QuizPassedDto quizPassedDto)
        {
            User user = await _authUtils.GetMeRequiredUserAsync(_contextAccessor, _userRepository);

            var existingQuiz = await _quizRepository.GetByIdAsync(quizPassedDto.QuizId);
            if (existingQuiz == null)
                throw new BadHttpRequestException("Квиз не найден.");

            ICollection<PassedUserQuestions> passedUserQuestions = new List<PassedUserQuestions>();

            for (int i = 0; i < quizPassedDto.ChoosesIndex.Count; i++)
            {
                var toAddQuestion = new PassedUserQuestions()
                {
                    ChooseIndex = quizPassedDto.ChoosesIndex[i],
                    Question = existingQuiz.Questions[i],
                    User = user
                };
                await _passedUserQuestionsRepository.SaveAsync(toAddQuestion);
                passedUserQuestions.Add(toAddQuestion);
            }


            PassedUserQuizzes passedUserQuizzes = new PassedUserQuizzes()
            {
                PassedQuestions = passedUserQuestions,
                Quiz = existingQuiz,
                User = user
            };
            await _passedUserQuizzesRepository.SaveAsync(passedUserQuizzes);


            if (user.LastPlay == null || user.LastPlay < DateTime.UtcNow.Date.AddDays(-1))
                user.ShockDay++;

            user.LastPlay = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            return new QuizDetailDto(existingQuiz);
        }

        public async Task<QuizDto> UpdateAsync(int id, QuizPostDto model)
        {
            User user = await _authUtils.GetMeRequiredUserAsync(_contextAccessor, _userRepository);

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

            existingQuiz.Questions = model.Questions.ToList();

            return new QuizDto((await _quizRepository.UpdateAsync(existingQuiz)));
        }
    }
}
