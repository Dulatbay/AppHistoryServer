using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Dtos.UserDtos
{
    public class AuthorDto : IModelId
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public AuthorDto(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
