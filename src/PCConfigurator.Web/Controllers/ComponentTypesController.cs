using System;
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
            var componentTypes = componentTypesManager.LoadAll();
            return View(new ComponentTypesIndexViewModel { ComponentTypes = componentTypes });
        }
    }
}