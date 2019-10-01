using Microsoft.AspNetCore.Mvc.Rendering;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurator.Web.Models
{
    public class AddComponentViewModel
    {
        public IEnumerable<SelectListItem> ComponentTypes { get; set; }

        [Required]
        [Display(Name = "Component Type")]
        public long SelectedComponentTypeId { get; set; }

        [Required]
        [RegularExpression(@"[^<>]*", ErrorMessage = "Html is not allowed!")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(256, ErrorMessage = "Name can't be greater than characters!")]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 0, maximum: double.MaxValue)]
        public decimal Price { get; set; }
    }
}
