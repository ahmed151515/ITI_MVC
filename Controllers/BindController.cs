using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
	public class BindController : Controller
	{
		// Model binding: : Map Action Parametere with request data (Form —Query String —RouteData)
		// Types

		// Bind Premitive type

		// http://localhost:5116/Bind/TestPremitive/2?name=ahmed&colors=red&colors=Black&colors=green
		public IActionResult TestPremitive(int id, string name, List<string> colors)
		{
			var res = new Dictionary<string, object>
			{
				{"name", name },
				{"id", id },
				{"colors", colors },
			};
			return Json(res);
		}
		// Bind Collection (Dictionary)

		// http://localhost:5116/Bind/TestDictionary?phones[ahmed]=015548&phones[arafa]=0117488
		public IActionResult TestDictionary(Dictionary<string, int> phones)
		{

			return Json(phones);
		}
		// Bind Complex/Custom type

		// http://localhost:5116/Bind/TestComplex?id=1&Name=CS&mangerName=Ahmed
		public IActionResult TestComplex(Department department)
		{

			return Json(department);
		}
		// http://localhost:5116/Bind/TestCustomBind?id=1&Name=CS&mangerName=Ahmed
		public IActionResult TestCustomBind(
			[Bind(include: "Id,Name")] Department department)
		{

			return Json(department);
		}

	}
}
