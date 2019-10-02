using PCConfigurator.Application;
using System.ComponentModel.DataAnnotations;

namespace PCConfigurator.Web.Models
{
    public class AddConfigurationWriteModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ComponentViewModel[] Components { get; set; }
    }
}
