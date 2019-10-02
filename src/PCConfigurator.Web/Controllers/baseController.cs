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
    class DictionaryAsArrayResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType.GetInterfaces().Any(i => i == typeof(IDictionary<,>) ||
                (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))))
            {
                return base.CreateArrayContract(objectType);
            }

            return base.CreateContract(objectType);
        }
    }

    public class BaseController : Controller
    {
        protected IActionResult JsonContent(object obj)
        {
            return this.JsonContent(obj, new CamelCasePropertyNamesContractResolver());
        }

        protected IActionResult JsonContent(object obj, IContractResolver contractResolver)
        {
            var serialzied = JsonConvert.SerializeObject(
                obj,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = contractResolver
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