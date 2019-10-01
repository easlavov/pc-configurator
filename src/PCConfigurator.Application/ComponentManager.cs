using PCConfigurator.Application.Repositories;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfigurator.Application
{
    public class ComponentManager : EntityManager<Component>
    {
        private readonly Repository<ComponentType> compTypeRepo;

        public ComponentManager(Repository<Component> repository, Repository<ComponentType> compTypeRepo) : 
            base(repository)
        {
            this.compTypeRepo = compTypeRepo ?? throw new ArgumentNullException(nameof(compTypeRepo));
        }

        public Component Add(ComponentWriteModel entity)
        {
            var selectedComponentType = compTypeRepo.GetById(entity.ComponentTypeId);
            var component = new Component(0, selectedComponentType, entity.Name, entity.Price);
            return repository.Add(component);
        }
    }
}
