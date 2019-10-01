using System.ComponentModel.DataAnnotations;

namespace PCConfigurator.Web.Models
{
    public class AddConfigurationWriteModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long[] ComponentIds { get; set; }
    }
}
