namespace PCConfigurator.Core
{
    public class ConfigurationComponent
    {
        public ConfigurationComponent(Component component, int quantity)
        {
            Component = component;
            Quantity = quantity;
        }

        private ConfigurationComponent(
            long configurationId, long componentId, int quantity)
        {
            ConfigurationId = configurationId;
            ComponentId = componentId;
            Quantity = quantity;
        }

        public long ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        public long ComponentId { get; set; }
        public virtual Component Component { get; set; }

        public int Quantity { get; set; }

        public decimal AccumulatedPrice => Component.Price * Quantity;
    }
}
