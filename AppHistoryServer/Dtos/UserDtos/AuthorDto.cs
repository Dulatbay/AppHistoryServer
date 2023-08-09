using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Dtos.UserDtos
{
    public class AuthorDto : IModelId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public AuthorDto(int id, string username)
        {
            Id = id;
            UserName = username;
        }
    }
}
