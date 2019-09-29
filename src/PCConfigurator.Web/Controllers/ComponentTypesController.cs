using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PCConfigurator.Application;
using PCConfigurator.Web.Models;

namespace PCConfigurator.Web.Controllers
{
    public class ComponentTypesController : Controller
    {
        private readonly ComponentTypesManager componentTypesManager;

        public ComponentTypesController(ComponentTypesManager componentTypesManager)
        {
            if (componentTypesManager == null)
                throw new ArgumentNullException(nameof(componentTypesManager));

            this.componentTypesManager = componentTypesManager;
        }

        public IActionResult Index()
        {
            //return View(new ComponentTypesIndexViewModel { ComponentTypes = componentTypes });
            return View();
        }

        //[HttpPost]
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
    }
}