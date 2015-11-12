using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CellPhoneAirTimeApp.Models
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid) return;

            var json = new
            {
                errors = actionContext.ModelState.Keys.SelectMany(k => actionContext.ModelState[k].Errors)
                    .Select(m => m.ErrorMessage).ToArray()
            };

            actionContext.Response = actionContext.Request.CreateResponse (HttpStatusCode.BadRequest, 
                json, 
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
        }
    }
}