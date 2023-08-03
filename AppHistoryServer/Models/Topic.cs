using AppHistoryServer.Dtos.ContentDtos;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AppHistoryServer.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int number { get; set; }

        public Module Module { get; set; } = null!;

        [Required]
        public Node content { get; set; } = null!;
    }
}
