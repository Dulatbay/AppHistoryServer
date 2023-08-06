using AppHistoryServer.Models;
using AppHistoryServer.Models.Interfaces;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Node : IModelId
    {
        public int Id { get; set; }

        public IEnumerable<Node>? childrens;
        public Component Component { get; set; }
    }
}
