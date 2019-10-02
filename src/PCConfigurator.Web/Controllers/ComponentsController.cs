using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PCConfigurator.Application;
using PCConfigurator.Core;
using PCConfigurator.Web.Models;

namespace PCConfigurator.Web.Controllers
{
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
            componentsManager.Delete(id);
            return Ok();
        }
    }
}