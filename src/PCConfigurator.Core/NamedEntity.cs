namespace PCConfigurator.Core
{
    using System;

    public abstract class NamedEntity : Entity
    {
        private string name;

        public NamedEntity(long id, string name) 
            : base(id)
        {
            Name = name;
        }

        public string Name 
        {
            get => name;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Name));

                name = value;
            }
        }
    }
}
