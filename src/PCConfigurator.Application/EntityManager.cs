namespace PCConfigurator.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    public class EntityManager<T> where T: Entity
    {
        private readonly Repository<T> repository;

        public EntityManager(Repository<T> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        public IEnumerable<T> LoadAll()
        {
            return repository.GetAll();
        }
        
        public Page<T> Load(PageRequest request)
        {
            var allItems = repository.GetAll();
            var itemsCount = allItems.Count();
            var items = repository.GetAll().Skip(request.Skip).Take(request.Take);
            var page = new Page<T> { Items = items, TotalItems = itemsCount };
            return page;
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
