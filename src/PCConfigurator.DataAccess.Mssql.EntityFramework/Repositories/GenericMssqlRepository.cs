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

        public T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T Add(T entity)
        {
            var entry = dbSet.Add(entity);
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
