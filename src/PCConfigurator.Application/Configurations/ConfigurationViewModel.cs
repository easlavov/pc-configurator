namespace PCConfigurator.Application.Configurations
{
    using System.Collections.Generic;

    using PCConfigurator.Application.Components;

    public class ConfigurationViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}
