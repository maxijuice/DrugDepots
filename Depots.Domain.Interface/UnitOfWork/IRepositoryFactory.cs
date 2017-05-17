using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.DAL.Interface.Repositories;

namespace Depots.DAL.Interface.UnitOfWork
{
    public interface IRepositoryFactory
    {
        TRepository GetRepository<T, TRepository>() where TRepository : IRepository<T>;
    }
}
