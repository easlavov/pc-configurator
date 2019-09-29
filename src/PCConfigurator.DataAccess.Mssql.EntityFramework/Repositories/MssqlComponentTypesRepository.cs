namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    using System;
    using System.Linq;

    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class MssqlComponentTypesRepository : ComponentTypesRepository
    {
        private readonly DbSet<ComponentType> dbSet;

        public MssqlComponentTypesRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            dbSet = context.Set<ComponentType>();
        }

        public IQueryable<ComponentType> GetAll()
        {
            return dbSet;
        }
    }
}
