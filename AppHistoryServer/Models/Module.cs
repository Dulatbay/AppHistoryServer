using System.ComponentModel.DataAnnotations;

namespace AppHistoryServer.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int Level { get; set; }

        [Required]
        public int Minutes { get; set; }

    }
}
