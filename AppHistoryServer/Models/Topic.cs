using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AppHistoryServer.Models
{
    public class Topic : IModelId
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int number { get; set; }

        [Required]
        public Module Module { get; set; } = null!;

        [Required]
        public Node content { get; set; } = null!;


        // Relationships
        public ICollection<Question>? Questions { get; set; }
        public ICollection<PassedUserTopics>? PassedUserTopics { get; set; }

        public ICollection<Term>? Terms { get; set; }
        public ICollection<Date>? Dates { get; set; }



    }
}
