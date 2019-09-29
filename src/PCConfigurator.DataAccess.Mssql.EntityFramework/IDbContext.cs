using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PCConfigurator.Core;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework
{
    public interface IDbContext
    {
        /// <summary>
        ///     Gets a set of entities from the context.
        /// </summary>
        /// <typeparam name="T">Entities type.</typeparam>
        DbSet<T> GetSet<T>() where T : class;

        /// <summary>
        ///     Saves uncommitted changes.
        /// </summary>
        void SaveChanges();

        public IDbContextTransaction BeginTransaction();
    }
}
