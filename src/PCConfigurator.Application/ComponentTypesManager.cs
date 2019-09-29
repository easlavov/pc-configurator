namespace PCConfigurator.Application
{
    using System;
    using System.Collections.Generic;

    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    public class ComponentTypesManager
    {
        private readonly ComponentTypesRepository repository;

        public ComponentTypesManager(ComponentTypesRepository componentTypesRepository)
        {
            if (componentTypesRepository == null)
                throw new ArgumentNullException(nameof(componentTypesRepository));

            repository = componentTypesRepository;
        }

        public IEnumerable<ComponentType> LoadAll()
        {
            return repository.GetAll();
        }
    }
}
