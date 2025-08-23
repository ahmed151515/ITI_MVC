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
			var skipActions = new List<string>
			{
				"Details"
			};
			var controllerTypes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => typeof(Controller).IsAssignableFrom(t) && !t.IsAbstract)
				.ToList();

			var routes = new List<RouteInfo>();


			foreach (var controller in controllerTypes)
			{
				var controllerName = controller.Name.Replace("Controller", "");
				var actions = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
										.Where(m => !skipActions.Contains(m.Name) && (typeof(IActionResult).IsAssignableFrom(m.ReturnType) || m.ReturnType == typeof(Task<IActionResult>)));



				routes.Add(new RouteInfo
				{
					Controller = controllerName,
					Actions = actions.Select(a => a.Name).ToList(),
				});

			}

			return routes;
		}

		public class RouteInfo
		{
			public string Controller { get; set; }
			public List<string> Actions { get; set; }
		}

	}
}
