namespace PCConfigurator.Core
{
    public class ConfigurationComponent
    {
        public long ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        public long ComponentId { get; set; }
        public virtual Component Component { get; set; }

        public int Quantity { get; set; }

        public decimal AccumulatedPrice => Component.Price * Quantity;
    }
}
