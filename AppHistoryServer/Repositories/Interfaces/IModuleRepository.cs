﻿using AppHistoryServer.Models;
using AppHistoryServer.Repositories.BaseInterfaces;

namespace AppHistoryServer.Repositories.Interfaces
{
    public interface IModuleRepository : IGetterRepository<Module>, ISaverRepository<Module>
    {
    }
}
