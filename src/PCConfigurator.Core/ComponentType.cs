namespace PCConfigurator.Core
{
    using System;

    public class ComponentType
    {
        public ComponentType(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public string Name { get; }
    }
}
