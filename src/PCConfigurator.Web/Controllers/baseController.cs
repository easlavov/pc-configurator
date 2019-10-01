using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PCConfigurator.Web.Models;

namespace PCConfigurator.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult JsonContent(object obj)
        {
            var serialzied = JsonConvert.SerializeObject(
                obj, 
                new JsonSerializerSettings 
                { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver() 
                });

            return this.Content(serialzied, "application/json");
        }

        //protected DataTablesResponse HandleDataTablesRequest(DataTablesRequest dtRequest)
        //{
        //    var result = componentTypesManager.Load(
        //        new PageRequest { Skip = dtRequest.Start, Take = dtRequest.Length });
        //    var response = new DataTablesResponse
        //    {
        //        data = result.Items.ToArray(),
        //        draw = dtRequest.Draw,
        //        recordsFiltered = result.TotalItems,
        //        recordsTotal = result.TotalItems
        //    };

        //    return response;
        //}
    }
}