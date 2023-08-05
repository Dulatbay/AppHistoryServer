using AppHistoryServer.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AppHistoryServer.Models
{
    public class RatingUserQuizzes : IModelId
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;
        
        [MaxLength(5)]
        [MinLength(1)]
        public double Rating { get; set; }
    }
}
