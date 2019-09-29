using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurator.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ComponentType> ComponentTypes { get; set; }
    }
}
