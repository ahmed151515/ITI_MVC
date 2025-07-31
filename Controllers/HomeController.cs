using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ITI_MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{

			var routes = GetAllRoutes();
			return View(routes);
		}

		private List<RouteInfo> GetAllRoutes()
		{
			var controllerTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => typeof(Controller).IsAssignableFrom(t) && !t.IsAbstract)
				.ToList();

			var routes = new List<RouteInfo>();

			foreach (var controller in controllerTypes)
			{
				var controllerName = controller.Name.Replace("Controller", "");
				var actions = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
										.Where(m => typeof(IActionResult).IsAssignableFrom(m.ReturnType) || m.ReturnType == typeof(Task<ActionResult>));

				foreach (var action in actions)
				{
					routes.Add(new RouteInfo
					{
						Controller = controllerName,
						Action = action.Name
					});
				}
			}

			return routes;
		}

		public class RouteInfo
		{
			public string Controller { get; set; }
			public string Action { get; set; }
		}

	}
}
