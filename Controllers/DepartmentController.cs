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


		//  Returns a form view for creating a new Department
		[HttpGet]
		public IActionResult New()
		{
			return View();
		}
		// Handles form submission and saves the new Department
		[HttpPost]
		public IActionResult SaveNew(Department department)
		{
			if (department.Name != null && department.Name != "can't name be come null")
			{

				context.Departments.Add(department);

				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				department.Name = "can't name be come null";
				return View("new", department);
			}
		}
	}
}
