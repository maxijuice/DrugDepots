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
        private readonly DbSet<T> set;
        private readonly DbContext context;

        public CommonRepository(DbContext context)
        {
            this.context = context;
            set = context.Set<T>();
        } 
        public virtual IQueryable<T> GetAll()
        {
            return set.AsQueryable();
        }

        public virtual T GetById(string id)
        {
            return set.Find(id);
        }

        public virtual void Create(T entity)
        {
            DbEntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entityEntry = context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}