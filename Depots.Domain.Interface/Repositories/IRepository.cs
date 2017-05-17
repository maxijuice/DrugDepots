using System.Linq;

namespace Depots.DAL.Interface.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}