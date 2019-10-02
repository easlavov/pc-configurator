namespace PCConfigurator.Web.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddComponentViewModel
    {
        public long Id { get; set; }

        public IEnumerable<SelectListItem> ComponentTypes { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Component Type")]
        public long SelectedComponentTypeId { get; set; }

        [Required]
        [RegularExpression(@"[^<>]*", ErrorMessage = "Html is not allowed!")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(256, ErrorMessage = "Name can't be greater than characters!")]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 1, maximum: double.MaxValue)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
    }
}
