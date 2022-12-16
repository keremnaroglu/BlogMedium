using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.ActionFilters
{
	public class ExceptionActionFilter:ExceptionFilterAttribute
	{
		public override Task OnExceptionAsync(ExceptionContext context)
		{
			var controllerName = context.RouteData.Values["controller"];
			var actionName = context.RouteData.Values["action"];
			Debug.WriteLine("Exception Filter : " + controllerName + " - " + actionName);
			return Task.CompletedTask;
		}
	}
}
