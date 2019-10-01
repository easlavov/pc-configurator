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

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public void Delete(long id)
        {
            var toDelete = dbSet.Find(id);
            dbSet.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
