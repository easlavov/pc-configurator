using Microsoft.AspNetCore.Mvc.Rendering;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurator.Web.Models
{
    public class AddComponentViewModel
    {
        public IEnumerable<SelectListItem> ComponentTypes { get; set; }

        public long SelectedComponentTypeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
