using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IQuestionRepository : IGetterRepository<Question>, ISaverRepository<Question>, IDeleterRepository<Question>, IUpdaterRepository<Question>
    {

    }
}
