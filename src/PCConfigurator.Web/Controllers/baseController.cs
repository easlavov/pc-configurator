namespace PCConfigurator.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

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
    }
}