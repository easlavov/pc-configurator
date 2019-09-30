namespace PCConfigurator.Core
{
    public class ConfigurationComponent
    {
        public long ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }

        public long ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
