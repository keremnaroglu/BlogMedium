using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace WebApplication1.ActionFilters
{
	public class LogActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controllerName = context.RouteData.Values["controller"];
			var actionName = context.RouteData.Values["action"];

			Debug.WriteLine("Action Log : " + controllerName+ " - " + actionName);
		}
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var data = context.HttpContext.Session.GetString("userName");

            if (data != null)
            {
                Controller controller = context.Controller as Controller;
                controller.ViewBag.UserName = data;

            }
        }
    }
}
