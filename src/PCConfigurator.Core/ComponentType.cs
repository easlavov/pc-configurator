namespace PCConfigurator.Core
{
    using System;
    using System.Collections.Generic;

    public class ComponentType : NamedEntity
    {
        public ComponentType(long id, string name)
            : base(id, name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        
        public virtual IList<Component> Components { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ComponentType)) return false;
            return (obj as ComponentType).GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (int)Id * Name.Length;
        }
    }
}
