namespace PCConfigurator.Application.Components
{
    using PCConfigurator.Application.ComponentTypes;

    public class ComponentViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ComponentTypeViewModel ComponentType { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
