using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Depots.DAL.Interface;
using Depots.DAL.Interface.Repositories;

namespace Depots.DAL.Concrete.Repositories
{
    public class CommonRepository<T> : IRepository<T> where T : class
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
            DbEntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}