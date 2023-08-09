using AppHistoryServer.Dtos.ContentDtos;
using AppHistoryServer.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHistoryServer.Models
{
    public class Topic : IModelId
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int Number { get; set; }

        public Module Module { get; set; } = null!;
        public int ModuleId { get; set; }

        public Node? Content { get; set; }
        public int ContentId { get; set; }

        


        // Relationships
        public ICollection<Question>? Questions { get; set; }
        public ICollection<PassedUserTopics>? PassedUserTopics { get; set; }

        public ICollection<Term>? Terms { get; set; }
        public ICollection<Date>? Dates { get; set; }



    }
}
