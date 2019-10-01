﻿using System;
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
    public class ManagementController : Controller
    {
        private readonly EntityManager<ComponentType> componentTypesManager;
        private readonly ComponentManager componentsManager;

        public ManagementController(
            EntityManager<ComponentType> componentTypesManager,
            ComponentManager componentsManager)
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

            var ser = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return this.Content(ser, "application/json");
        }

        [HttpPost]
        public IActionResult DeleteComponent(long id)
        {
            componentsManager.Delete(id);
            return Ok();
        }
    }
}