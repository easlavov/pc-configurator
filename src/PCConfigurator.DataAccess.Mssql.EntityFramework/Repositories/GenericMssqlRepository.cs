namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    using System;
    using System.Linq;

    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class GenericMssqlRepository<T> : Repository<T> where T: Entity
    {
        protected readonly DbSet<T> dbSet;
        protected readonly DbContext context;

        public GenericMssqlRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual IQueryable<T> GetAllById(params long[] ids)
        {
            return dbSet.Where(entity => ids.Contains(entity.Id));
        }

        public T Add(T entity)
        {
            var entry = dbSet.Add(entity);
            context.SaveChanges();
            return entry.Entity;
        }

        public T Update(T entity)
        {
            var entry = dbSet.Update(entity);
            context.SaveChanges();
            return entry.Entity;
        }

        public void Delete(long id)
        {
            var toDelete = dbSet.Find(id);
            dbSet.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
