using AppHistoryServer.Dtos.Interfaces;

namespace AppHistoryServer.Dtos.ModuleDtos
{
    public class ModuleDto : IDtoModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
