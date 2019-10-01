using PCConfigurator.Core;
using System;
using System.Collections.Generic;

using System.Text;

namespace PCConfigurator.Application
{
    public class ConfigurationWriteModel
    {
        public string Name { get; set; }

        public IEnumerable<ComponentWriteModel> Components { get; set; }
    }
}
