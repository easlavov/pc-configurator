namespace PCConfigurator.Application.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PCConfigurator.Application.Components;
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

        public Configuration Add(ConfigurationWriteModel model)
        {
            var configuration = BuildFromWriteModel(model);
            return repository.Add(configuration);
        }

        public Configuration Update(ConfigurationWriteModel model)
        {
            var configuration = repository.GetById(model.Id);
            configuration.ConfigurationComponents = ExtractValidComponents(model);
            configuration.Name = model.Name;
            return repository.Update(configuration);
        }

        public ConfigurationViewModel GetById(long id)
        {
            var configuration = repository.GetById(id);
            var viewModel = new ConfigurationViewModel
            {
                Components = configuration.ConfigurationComponents.Select(
                        x => new ComponentViewModel { Id = x.ComponentId, Quantity = x.Quantity }),
                Id = id,
                Name = configuration.Name
            };

            return viewModel;
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
                int quantity = model.Components.First(cmp => cmp.Id == item.Id).Quantity;
                var cfgCmp = new ConfigurationComponent { ComponentId = item.Id, Quantity = quantity };
                configComponents.Add(cfgCmp);
            }

            return configComponents;
        }
    }
}
