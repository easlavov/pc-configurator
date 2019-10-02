namespace PCConfigurator.Application.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PCConfigurator.Application.ComponentTypes;
    using PCConfigurator.Application.Exceptions;
    using PCConfigurator.Application.Repositories;
    using PCConfigurator.Core;

    public class ComponentsManager : EntityManager<Component>
    {
        private readonly Repository<ComponentType> compTypeRepo;

        public ComponentsManager(Repository<Component> repository, Repository<ComponentType> compTypeRepo) : 
            base(repository)
        {
            this.compTypeRepo = compTypeRepo ?? throw new ArgumentNullException(nameof(compTypeRepo));
        }

        public new IEnumerable<ComponentViewModel> LoadAll()
        {
            var viewModel = repository.GetAll().Select(x => new ComponentViewModel 
            { 
                Id = x.Id, 
                Name = x.Name,
                ComponentType = new ComponentTypeViewModel 
                { 
                    Id = x.ComponentTypeId, 
                    Name = x.ComponentType.Name 
                },
                Price = x.Price
            });

            return viewModel;
        }

        public IDictionary<ComponentTypeViewModel, IEnumerable<ComponentViewModel>> GetByComponentType()
        {
            var comps = LoadAll();
            var byType = comps.GroupBy(x => x.ComponentType).ToDictionary(x => x.Key, x => x.AsEnumerable());
            return byType;
        }

        public Component Add(ComponentWriteModel model)
        {
            var selectedComponentType = compTypeRepo.GetById(model.ComponentTypeId);
            var component = new Component(0, selectedComponentType, model.Name, model.Price);
            return repository.Add(component);
        }

        public Component Update(ComponentWriteModel model)
        {
            var component = repository.GetById(model.Id);
            component.Name = model.Name;
            component.ComponentTypeId = model.ComponentTypeId;
            component.Price = model.Price;

            return repository.Update(component);
        }

        public override void Delete(long id)
        {
            var component = repository.GetById(id);
            if (component.IsUsed)
                throw new ComponentInUseException();

            base.Delete(id);
        }
    }
}
