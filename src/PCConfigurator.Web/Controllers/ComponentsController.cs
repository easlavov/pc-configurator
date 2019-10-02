namespace PCConfigurator.Web.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using PCConfigurator.Application;
    using PCConfigurator.Application.Components;
    using PCConfigurator.Application.Exceptions;
    using PCConfigurator.Core;

    using PCConfigurator.Web.Models;
    using PCConfigurator.Web.Models.View;

    public class ComponentsController : BaseController
    {
        private readonly EntityManager<ComponentType> componentTypesManager;
        private readonly ComponentsManager componentsManager;

        public ComponentsController(
            EntityManager<ComponentType> componentTypesManager,
            ComponentsManager componentsManager)
        {
            if (componentTypesManager == null)
                throw new ArgumentNullException(nameof(componentTypesManager));

            if (componentsManager == null)
                throw new ArgumentNullException(nameof(componentsManager));

            this.componentTypesManager = componentTypesManager;
            this.componentsManager = componentsManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadComponentTypes(DataTablesRequest dtRequest)
        {
            var result = componentTypesManager.Load(
                new PageRequest { Skip = dtRequest.Start, Take = dtRequest.Length });
            var response = new DataTablesResponse
            {
                data = result.Items.ToArray(),
                draw = dtRequest.Draw,
                recordsFiltered = result.TotalItems,
                recordsTotal = result.TotalItems
            };

            return Json(response);
        }

        [HttpGet]
        public IActionResult AddComponent()
        {
            var viewModel = new AddComponentViewModel 
            { 
                ComponentTypes = componentTypesManager.LoadAll().Select(ct => new SelectListItem { Text = ct.Name, Value = ct.Id.ToString() }) 
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComponent([FromForm]AddComponentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ComponentTypes = componentTypesManager.LoadAll()
                .Select(ct => new SelectListItem { Text = ct.Name, Value = ct.Id.ToString(), Selected = ct.Id == model.SelectedComponentTypeId });
                return this.View(model);
            }

            componentsManager.Add(new ComponentWriteModel { Name = model.Name, ComponentTypeId = model.SelectedComponentTypeId, Price = model.Price });

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditComponent(long id)
        {
            var component = componentsManager.GetById(id);
            var viewModel = new AddComponentViewModel
            {
                Id = component.Id,
                SelectedComponentTypeId = component.ComponentTypeId,
                Name = component.Name,
                Price = component.Price,
                ComponentTypes = componentTypesManager.LoadAll().Select(ct => new SelectListItem { Text = ct.Name, Value = ct.Id.ToString() }),
                
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditComponent([FromForm]AddComponentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ComponentTypes = componentTypesManager.LoadAll()
                    .Select(ct => new SelectListItem 
                        { Text = ct.Name, Value = ct.Id.ToString(), Selected = ct.Id == model.SelectedComponentTypeId });
                return this.View(model);
            }

            componentsManager.Update(new ComponentWriteModel 
            {
                Id = model.Id,
                Name = model.Name, 
                ComponentTypeId = model.SelectedComponentTypeId, 
                Price = model.Price 
            });

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteComponentType(long id)
        {
            componentTypesManager.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult LoadAllComponents()
        {
            var components = componentsManager.GetByComponentType();
            return base.JsonContent(components, new DictionaryAsArrayResolver());
        }

        [HttpGet]
        public IActionResult LoadComponents(DataTablesRequest dtRequest)
        {
            var result = componentsManager.Load(
                new PageRequest { Skip = dtRequest.Start, Take = dtRequest.Length });
            var response = new DataTablesResponse
            {
                data = result.Items.ToArray(),
                draw = dtRequest.Draw,
                recordsFiltered = result.TotalItems,
                recordsTotal = result.TotalItems
            };
            
            return base.JsonContent(response);
        }

        [HttpPost]
        public IActionResult DeleteComponent(long id)
        {
            try
            {
                componentsManager.Delete(id);
                return Ok();
            }
            catch (ComponentInUseException ex)
            {
                return Ok(new { error = ex.Message });
            }
        }
    }
}