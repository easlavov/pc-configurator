namespace PCConfigurator.Application.Components
{
    using PCConfigurator.Application.ComponentTypes;
    using PCConfigurator.Core;

    public class ComponentViewModel
    {
        public static ComponentViewModel FromComponent(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentType = new ComponentTypeViewModel 
                { 
                    Id = component.ComponentType.Id, 
                    Name = component.ComponentType.Name 
                },
                Name = component.Name,
                Price = component.Price
            };
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public ComponentTypeViewModel ComponentType { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
