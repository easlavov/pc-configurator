namespace PCConfigurator.Application.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

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

        public ConfigurationViewModel Add(ConfigurationWriteModel model)
        {
            var configuration = BuildFromWriteModel(model);
            var entity = repository.Add(configuration);
            return ConfigurationViewModel.From(configuration);
        }

        public ConfigurationViewModel Update(ConfigurationWriteModel model)
        {
            var configuration = repository.GetById(model.Id);
            configuration.ConfigurationComponents = ExtractValidComponents(model);
            configuration.Name = model.Name;
            var updated = repository.Update(configuration);
            return ConfigurationViewModel.From(updated);
        }

        public ConfigurationViewModel GetById(long id)
        {
            var configuration = repository.GetById(id);
            return ConfigurationViewModel.From(configuration);
        }

        private Configuration BuildFromWriteModel(ConfigurationWriteModel model)
        {
            List<ConfigurationComponent> configComponents = ExtractValidComponents(model);

            var configuration = new Configuration(model.Id, model.Name, configComponents);
            return configuration;
        }

        private List<ConfigurationComponent> ExtractValidComponents(ConfigurationWriteModel model)
        {
            var components = compRepo.GetAllById(model.Components.Select(cmp => cmp.Id).ToArray());
            var configComponents = new List<ConfigurationComponent>();
            foreach (var item in components)
            {
                var quantity = model.Components.First(cmp => cmp.Id == item.Id).Quantity;
                var cfgCmp = new ConfigurationComponent(item, quantity);
                configComponents.Add(cfgCmp);
            }

            return configComponents;
        }
    }
}
