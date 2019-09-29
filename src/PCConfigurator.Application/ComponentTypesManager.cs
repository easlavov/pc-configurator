namespace PCConfigurator.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        
        public Page<ComponentType> Load(PageRequest request)
        {
            var allItems = repository.GetAll();
            var itemsCount = allItems.Count();
            var items = repository.GetAll().Skip(request.Skip).Take(request.Take);
            var page = new Page<ComponentType> { Items = items, TotalItems = itemsCount };
            return page;
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
