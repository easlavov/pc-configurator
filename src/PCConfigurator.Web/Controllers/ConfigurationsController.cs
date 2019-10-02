namespace PCConfigurator.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using PCConfigurator.Application;
    using PCConfigurator.Application.Components;
    using PCConfigurator.Application.Configurations;

    using PCConfigurator.Web.Models;

    public class ConfigurationsController : BaseController
    {
        private readonly ConfigurationsManager configurationsManager;
        private readonly ComponentsManager componentsManager;

        public ConfigurationsController(
            ConfigurationsManager configurationsManager, 
            ComponentsManager componentsManager)
        {
            this.configurationsManager = 
                configurationsManager ?? throw new ArgumentNullException(nameof(configurationsManager));

            this.componentsManager = 
                componentsManager ?? throw new ArgumentNullException(nameof(componentsManager));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Load(DataTablesRequest dtRequest)
        {
            var result = configurationsManager.Load(
                new PageRequest { Skip = dtRequest.Start, Take = dtRequest.Length });
            var response = new DataTablesResponse
            {
                data = result.Items.ToArray(),
                draw = dtRequest.Draw,
                recordsFiltered = result.TotalItems,
                recordsTotal = result.TotalItems
            };

            return this.JsonContent(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddConfigurationViewModel
            {
                Components = componentsManager.LoadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddConfigurationWriteModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            configurationsManager.Add(new ConfigurationWriteModel { Name = model.Name, Components = model.Components });

            return this.Ok();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AddConfigurationWriteModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            configurationsManager.Update(new ConfigurationWriteModel
            {
                Id = model.Id,
                Components = model.Components,
                Name = model.Name
            });

            return this.Ok();
        }

        [HttpGet]
        public IActionResult LoadById(long id)
        {
            var vm = configurationsManager.GetById(id);
            return base.JsonContent(vm);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            configurationsManager.Delete(id);
            return Ok();
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
