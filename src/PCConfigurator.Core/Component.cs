namespace PCConfigurator.Core
{
    using System;

    public class Component : Entity
    {
        public Component(long id, ComponentType componentType, string name, decimal price) : 
            base(id)
        {
            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException($"{nameof(price)} must be a non-negative value!");

            ComponentType = componentType;
            Name = name;
            Price = price;
        }

        private Component(long id, string name, decimal price)
            : base (id)
        {
            Name = name;
            Price = price;
        }

        public long ComponentTypeId { get; set; }

        public ComponentType ComponentType { get; set; }

        public string Name { get; }

        public decimal Price { get; }
    }
}
