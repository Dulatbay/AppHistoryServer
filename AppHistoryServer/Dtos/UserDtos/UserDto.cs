using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.UserDtos
{
    public class UserDto : IDtoModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public UserDto(User? user)
        {
            if(user == null) throw new ArgumentNullException(nameof(user));
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
        }

        public static IEnumerable<UserDto> GetAll(IEnumerable<User>? users)
        {
            if (users == null)
                yield break;

            foreach (var user in users)
            {
                yield return new UserDto(user);
            }
        }
    }
}

