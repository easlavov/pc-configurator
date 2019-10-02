namespace PCConfigurator.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCConfigurator.Application.Components;

    public class AddConfigurationWriteModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ComponentViewModel[] Components { get; set; }

        public ComponentViewModel[] SelectedComponents { get; set; }
    }
}
