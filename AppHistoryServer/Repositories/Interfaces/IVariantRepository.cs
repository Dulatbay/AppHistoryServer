using AppHistoryServer.Models.Variant;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IVariantRepository : IGetterRepository<Variant>, ISaverRepository<Variant>, IUpdaterRepository<Variant>
    {
    }
}
