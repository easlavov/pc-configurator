namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using PCConfigurator.Core;

    public class ConfigurationsRepository : GenericMssqlRepository<Configuration>
    {
        public ConfigurationsRepository(DbContext context) 
            : base(context)
        {
        }

        public override Configuration GetById(long id)
        {
            return base.dbSet.Include(
                $"{nameof(Configuration.ConfigurationComponents)}.{nameof(ConfigurationComponent.Component)}")
                .SingleOrDefault(c => c.Id == id);
        }

        public override IQueryable<Configuration> GetAll()
        {
            var list = base.dbSet.Include($"{nameof(Configuration.ConfigurationComponents)}.{nameof(ConfigurationComponent.Component)}")
                                    .ToList();
            return list.AsQueryable();
        }
    }
}
