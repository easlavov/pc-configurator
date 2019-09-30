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
            
            Name = name;
            Components = components ?? throw new ArgumentNullException(nameof(components));
        }

        private Configuration(long id, string name)
            : this(id, name, new List<Component>())
        { }

        public string Name { get; }

        public ICollection<Component> Components { get; }

        public decimal TotalPrice => Components.Sum(cmpnt => cmpnt.Price);
    }
}
