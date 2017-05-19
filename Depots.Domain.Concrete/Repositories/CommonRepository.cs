using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Depots.DAL.Interface;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.EntityInterfaces;

namespace Depots.DAL.Concrete.Repositories
{
    public class CommonRepository<T> : IRepository<T> where T : class, IUnique
    {
        protected readonly DbSet<T> set;
        protected readonly DbContext context;

        public CommonRepository(DbContext context)
        {
            this.context = context;
            set = context.Set<T>();
        } 

        public virtual IQueryable<T> GetAll()
        {
            return set;
        }

        public virtual T GetById(dynamic id)
        {
            return set.Find(id);
        }

        public virtual void Create(T entity)
        {
            DbEntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Added;
        }

        public virtual void Delete(T entity)
        {
            T entityToDelete = set.Find(entity.EntityID);
            DbEntityEntry entityEntry = context.Entry(entityToDelete);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            T entityToUpdate = set.Find(entity.EntityID);
            DbEntityEntry entityEntry = context.Entry(entityToUpdate);
            entityEntry?.CurrentValues.SetValues(entity);
        }
    }
}