using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Node
    {
        public IEnumerable<Node>? childrens;
        public Component Component { get; set; }
    }
}
