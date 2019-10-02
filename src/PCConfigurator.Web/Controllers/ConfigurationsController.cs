namespace PCConfigurator.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using PCConfigurator.Application;
    using PCConfigurator.Web.Models;
    using System.Linq;

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

            return Json(response);
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
                //model.ComponentTypes = componentTypesManager.LoadAll()
                //.Select(ct => new SelectListItem { Text = ct.Name, Value = ct.Id.ToString(), Selected = ct.Id == model.SelectedComponentTypeId });
                return this.View(model);
            }

            configurationsManager.Add(new ConfigurationWriteModel { Name = model.Name, Components = model.ComponentIds });
            //componentsManager.Add(new ComponentWriteModel { Name = model.Name, ComponentTypeId = model.SelectedComponentTypeId, Price = model.Price });

            return this.RedirectToAction(nameof(Index));
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
