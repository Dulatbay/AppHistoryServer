using System.ComponentModel.DataAnnotations;

namespace AppHistoryServer.Models
{
    public class RatingUserQuizzes
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;
        
        [MaxLength(5)]
        [MinLength(1)]
        public double Rating { get; set; }
    }
}
