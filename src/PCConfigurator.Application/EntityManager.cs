namespace PCConfigurator.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    public class EntityManager<TEntity> where TEntity: Entity
    {
        protected readonly Repository<TEntity> repository;

        public EntityManager(Repository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        public IEnumerable<TEntity> LoadAll()
        {
            return repository.GetAll();
        }
        
        public Page<TEntity> Load(PageRequest request)
        {
            var allItems = repository.GetAll();
            var itemsCount = allItems.Count();
            var items = repository.GetAll().Skip(request.Skip).Take(request.Take);
            var page = new Page<TEntity> { Items = items, TotalItems = itemsCount };
            return page;
        }

        public virtual void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
