﻿namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories
{
    using System.Linq;

    using PCConfigurator.Core;

    using Microsoft.EntityFrameworkCore;

    public class ComponentRepository : GenericMssqlRepository<Component>
    {
        public ComponentRepository(DbContext context) 
            : base(context)
        { }

        public override Component GetById(long id)
        {
            return base.dbSet.Include(c => c.ComponentType)
                .Include(c => c.ConfigurationComponents)
                .SingleOrDefault(c=> c.Id == id);
        }

        public override IQueryable<Component> GetAll()
        {
            var list = base.dbSet.Include(c => c.ComponentType).ToList();
            return list.AsQueryable();
        }

        public override IQueryable<Component> GetAllById(params long[] ids)
        {
            return base.GetAllById(ids).Include(cmp => cmp.ComponentType);            
        }
    }
}
