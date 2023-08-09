using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Node : IModelId
    {
        public int Id { get; set; }

        public IEnumerable<Node>? childrens;
        public Component Component { get; set; }

        public Topic? Topic { get; set; }
        
        public int TopicId { get; set; }
    }
}
