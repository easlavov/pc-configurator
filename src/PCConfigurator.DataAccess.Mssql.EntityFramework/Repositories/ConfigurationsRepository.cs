using Microsoft.EntityFrameworkCore;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    public class ConfigurationsRepository : GenericMssqlRepository<Configuration>
    {
        public ConfigurationsRepository(DbContext context) 
            : base(context)
        {
        }

        public override IQueryable<Configuration> GetAll()
        {
            var list = base.dbSet.Include($"{nameof(Configuration.ConfigurationComponents)}.{nameof(ConfigurationComponent.Component)}")
                                    .ToList();
            return list.AsQueryable();
        }
    }
}
