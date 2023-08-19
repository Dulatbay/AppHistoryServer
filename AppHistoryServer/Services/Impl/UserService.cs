using AppHistoryServer.Dtos.UserDtos;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Interfaces;
using AppHistoryServer.Utils;

namespace AppHistoryServer.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly AuthUtils _authUtils;
        private readonly ITopicService _topicService;
        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ITopicService topicService)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _authUtils = new AuthUtils(_configuration);
            _topicService = topicService;
        }

        public IEnumerable<UserDto> GetAll() => UserDto.GetAll(_userRepository.GetAll());

        public async Task<UserDto?> GetUserByEmailAsync(string email) => new UserDto(await _userRepository.GetUserByEmailAsync(email));

        public async Task<UserDto?> GetByIdAsync(int id) => new UserDto(await _userRepository.GetByIdAsync(id));

        public async Task<object> GetMeShockDaysAsync()
        {
            var token = AuthUtils.GetTokenFromHeader(_httpContextAccessor);
            if (token == null) return new { shockDay = 0};

            var userDto = _authUtils.GetUserFromToken(token);
            if (userDto == null) return new { shockDay = 0 };

            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user == null) return new { shockDay = 0};
            if(user.LastPlay == null || user.LastPlay.ToString()?.Length == 0) return new { shockDay = 0};
            return new { shockDay = user.ShockDay, lastPlay = user.LastPlay.ToString() }; 
        }

        public async Task<UserCardDto> GetUserCardByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new BadHttpRequestException("User not found");

            var statesResult = await _userRepository.GetUserCardAsync(id);
            
            if(statesResult == null) throw new BadHttpRequestException("Cannot get detail info by user");

            int correctAnswers = 0;

            foreach (var passedQuestion in statesResult.PassedUserQuestions)
            {
                if(passedQuestion.ChooseIndex == passedQuestion.Question.CorrectVarianIndex)
                    correctAnswers++;
            }


            var statesDto = new States
            {
                CorrectAnswers = correctAnswers,
                IncorrectAnswers = statesResult.PassedUserQuestions.Count() - correctAnswers,
                FirstPlace = 0,
                SecondPlace = 0,
                ThirdPlace = 0,
                FriendsCount = 0,
                ParticipatedTournaments = 0,
                PassedHistoryPercent = (statesResult.PassedUserTopics.Count() * 100) / _topicService.GetAll().Count(),
                PassedQuizzes = statesResult.PassedUserQuizzes.Count(),
                ShockDay = statesResult.ShockDay
            };

            return new UserCardDto(user, statesDto);
        }
    }
}
