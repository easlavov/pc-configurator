using PCConfigurator.Application.Repositories;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCConfigurator.Application
{
    public class ConfigurationsManager : EntityManager<Configuration>
    {
        private readonly Repository<Component> compRepo;

        public ConfigurationsManager(
            Repository<Configuration> repository, 
            Repository<Component> compRepo) 
            : base(repository)
        {
            this.compRepo = compRepo ?? throw new ArgumentNullException(nameof(compRepo));
        }

        public Configuration Add(ConfigurationWriteModel model)
        {
            var components = compRepo.GetAllById(model.Components.Select(cmp => cmp.Id).ToArray());
            var configComponents = new List<ConfigurationComponent>();
            foreach (var item in components)
            {
                int quantity = model.Components.First(cmp => cmp.Id == item.Id).Quantity;
                var cfgCmp = new ConfigurationComponent { ComponentId = item.Id, Quantity = quantity };
                configComponents.Add(cfgCmp);
            }

            var configuration = new Configuration(0, model.Name, configComponents);
            return repository.Add(configuration);
        }
    }
}
