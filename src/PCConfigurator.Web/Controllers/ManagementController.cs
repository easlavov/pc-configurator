using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PCConfigurator.Application;
using PCConfigurator.Core;
using PCConfigurator.Web.Models;

namespace PCConfigurator.Web.Controllers
{
    public class ManagementController : Controller
    {
        private readonly EntityManager<ComponentType> componentTypesManager;
        private readonly EntityManager<Component> componentsManager;

        public ManagementController(
            EntityManager<ComponentType> componentTypesManager,
            EntityManager<Component> componentsManager)
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

        [HttpPost]
        public IActionResult DeleteComponentType(long id)
        {
            componentTypesManager.Delete(id);
            return Ok();
        }

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

            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteComponent(long id)
        {
            componentsManager.Delete(id);
            return Ok();
        }
    }
}