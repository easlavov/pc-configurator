using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PCConfigurator.Application
{
    public class ConfigurationViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}
