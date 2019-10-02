﻿namespace PCConfigurator.Core
{
    using System;
    using System.Collections.Generic;

    public class Component : NamedEntity
    {
        public Component(long id, ComponentType componentType, string name, decimal price) : 
            base(id, name)
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

        protected Component(long id, string name, decimal price)
            : base (id, name)
        {
            Name = name;
            Price = price;
        }

        public long ComponentTypeId { get; set; }

        public virtual ComponentType ComponentType { get; set; }
        
        public decimal Price { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Component)) return false;
            return (obj as Component).GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (int)Id * Name.Length;
        }

        private IList<ConfigurationComponent> ConfigurationComponents { get; set; } = new List<ConfigurationComponent>();
    }
}
