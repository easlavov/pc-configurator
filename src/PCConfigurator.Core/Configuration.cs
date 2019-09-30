namespace PCConfigurator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Configuration : Entity
    {
        public Configuration(long id, string name, ICollection<Component> components)
            : base(id)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (components == null)
                throw new ArgumentNullException(nameof(components));

            var groups = components.GroupBy(cmpnt => cmpnt.ComponentType);

            if (groups.Count() != components.Count)
                throw new ArgumentException($"All items in the {nameof(components)} collection must me of unique {nameof(ComponentType)}!");

            Name = name;
            Components = components;
        }

        private Configuration(long id, string name)
            : this(id, name, new List<Component>())
        { }

        public string Name { get; }

        public ICollection<Component> Components { get; }

        public decimal TotalPrice => Components.Sum(cmpnt => cmpnt.Price);

        
    }
}
