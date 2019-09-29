using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCConfigurator.Application;
using PCConfigurator.Web.Models;

namespace PCConfigurator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ComponentTypesManager componentTypesManager;

        public HomeController(ILogger<HomeController> logger, ComponentTypesManager componentTypesManager)
        {
            if (componentTypesManager == null)
                throw new ArgumentNullException(nameof(componentTypesManager));

            _logger = logger;
            this.componentTypesManager = componentTypesManager;
        }

        public IActionResult Index()
        {
            var componentTypes = componentTypesManager.LoadAll();
            return View(new HomeViewModel { ComponentTypes = componentTypes });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
