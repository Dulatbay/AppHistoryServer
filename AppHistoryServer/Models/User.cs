using Microsoft.AspNetCore.Identity;

namespace AppHistoryServer.Models
{
    public class User : IdentityUser
    {
        public int ShockDay { get; set; }

        public League League { get; set; }

        public DateTime LastPlay { get; set; }
        public string? ImageUrl { get; set; }
        public Topic lastTopic{ get; set; }
    }
}
