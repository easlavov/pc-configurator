using PCConfigurator.Application.Repositories;
using PCConfigurator.Core;
using System;
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
            var configuration = new Configuration(0, model.Name, components.ToList());
            return repository.Add(configuration);
        }
    }
}
