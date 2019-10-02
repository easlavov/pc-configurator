namespace PCConfigurator.Web.Models.View
{
    using System.Collections.Generic;

    using PCConfigurator.Application.Components;

    public class AddConfigurationViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}
