namespace PCConfigurator.Application.Configurations
{
    using System.Collections.Generic;
    using System.Linq;

    using PCConfigurator.Application.Components;
    using PCConfigurator.Core;

    public class ConfigurationViewModel
    {
        public static ConfigurationViewModel From(Configuration configuration)
        {
            return new ConfigurationViewModel
            {
                Components = configuration.ConfigurationComponents.Select(
                        x => new ComponentViewModel { Id = x.ComponentId, Quantity = x.Quantity }),
                Id = configuration.Id,
                Name = configuration.Name
            };
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}
