using AppHistoryServer.Models;

namespace AppHistoryServer.Dtos.ContentDtos
{
    public class Node
    {
        public int Id { get; set; }

        public IEnumerable<Node>? childrens;
        public Component Component { get; set; }
    }
}
