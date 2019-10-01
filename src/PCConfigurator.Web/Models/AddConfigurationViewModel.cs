using PCConfigurator.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurator.Web.Models
{
    public class AddConfigurationViewModel
    {
        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}
