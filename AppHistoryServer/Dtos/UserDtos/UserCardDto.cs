using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.UserDtos
{
    public class States : IDtoModel
    {
        public float PassedHistoryPercent { get; set; }
        public int PassedQuizzes { get; set; }
        public int ParticipatedTournaments { get; set; }
        public int FirstPlace { get; set; }
        public int SecondPlace { get; set; }
        public int ThirdPlace { get; set; }
        public int FriendsCount { get; set; }
        public int ShockDay { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }

    public class UserCardDto : IDtoModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public States States { get; set; } = null!;

        public UserCardDto(User user, States states)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            States = states;
        }
    }
}
