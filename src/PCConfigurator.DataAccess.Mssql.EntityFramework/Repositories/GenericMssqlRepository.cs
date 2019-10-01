namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    using System;
    using System.Linq;

    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class GenericMssqlRepository<T> : Repository<T> where T: Entity
    {
        private readonly DbSet<T> dbSet;
        private readonly DbContext context;

        public GenericMssqlRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            this.context = context;
            dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
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
