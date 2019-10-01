﻿using PCConfigurator.Application.Repositories;
using PCConfigurator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCConfigurator.Application
{
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

        public Component Add(ComponentWriteModel entity)
        {
            var selectedComponentType = compTypeRepo.GetById(entity.ComponentTypeId);
            var component = new Component(0, selectedComponentType, entity.Name, entity.Price);
            return repository.Add(component);
        }
    }
}
