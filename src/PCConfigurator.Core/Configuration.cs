namespace PCConfigurator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Configuration : NamedEntity
    {
        public Configuration(long id, string name, IList<ConfigurationComponent> components)
            : base(id, name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (components == null)
                throw new ArgumentNullException(nameof(components));            

            Name = name;
            ConfigurationComponents = components;
        }

        private Configuration(long id, string name)
            : this(id, name, new List<ConfigurationComponent>())
        { }
        
        //public IList<Component> Components
        //{
        //    get => ConfigurationComponents.Select(cc => cc.Component).ToList();

        //    set
        //    {
        //        ThrowIfDuplicateComponentTypesAreFound(value);
        //        ConfigurationComponents.Clear();
        //        foreach (var component in value)
        //        {
        //            ConfigurationComponents.Add(new ConfigurationComponent
        //            {
        //                Component = component,
        //                ComponentId = component.Id,
        //                Configuration = this,
        //                ConfigurationId = this.Id
        //            });
        //        }
        //    }
        //}

        public decimal TotalPrice => ConfigurationComponents.Sum(cmpnt => cmpnt.AccumulatedPrice);

        public IList<ConfigurationComponent> ConfigurationComponents { get; set; } = new List<ConfigurationComponent>();

        //private void ThrowIfDuplicateComponentTypesAreFound(IList<Component> value)
        //{
        //    var groups = value.GroupBy(cmpnt => cmpnt.ComponentType);

        //    if (groups.Count() != value.Count)
        //        throw new ArgumentException($"All items in the {nameof(Components)} list must be of unique {nameof(ComponentType)}!");
        //}
    }
}
