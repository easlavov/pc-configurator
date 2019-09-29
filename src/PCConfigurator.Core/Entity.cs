namespace PCConfigurator.Core
{
    using System;

    public abstract class Entity
    {
        public Entity(long id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(id)} must be greater than 0!");

            Id = id;
        }
        
        public long Id { get; }
    }
}
