namespace AppHistoryServer.Dtos
{
    public class AuthResponseDto
    {
        private string? Token { get; set; }

        public AuthResponseDto(string? token)
        {
            Token = token;
        }
    }
}
