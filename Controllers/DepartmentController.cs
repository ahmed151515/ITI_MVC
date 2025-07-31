using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		private ITIEntities context = new ITIEntities();
		public IActionResult Index()
		{



			var data = context.Departments.ToList();

			return View("Index", data);
		}
	}
}
