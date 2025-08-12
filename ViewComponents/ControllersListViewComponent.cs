using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ITI_MVC.ViewComponents
{
	public class ControllersListViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var controllers = typeof(Program)
				.Assembly
				.GetTypes()
				.Where(t => typeof(Controller).IsAssignableFrom(t) && !t.IsAbstract
				&& t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
				.Any(m => m.Name == "Index")
				)
				.Select(t => t.Name.Replace("Controller", ""))
				.OrderBy(name => name)
				.ToList();

			return View(controllers);
		}
	}
}
