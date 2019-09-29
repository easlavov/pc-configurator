namespace PCConfigurator.Core
{
    using System;

    public class ComponentType : Entity
    {
        public ComponentType(long id, string name)
            : base(id)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public string Name { get; }
    }
}
