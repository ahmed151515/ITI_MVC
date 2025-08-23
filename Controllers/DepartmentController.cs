using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		private ITIEntities context = new ITIEntities();


		public IActionResult Employees(int dept_Id)
		{

			var emps = context.Employees.AsNoTracking().Where(e => e.Dept_Id == dept_Id).ToList();
			return PartialView("_EmployeesPartial", emps);
		}
		public IActionResult Index()
		{

			var data = context.Departments.ToList();


			return View("Index", data);
		}
		public IActionResult Details(int id)
		{

			var data = context.Departments.FirstOrDefault(d => d.Id == id);


			return View(data);
		}
		public IActionResult DropDownList()
		{

			var data = new SelectList(context.Departments, "Id", "Name");


			return View(data);
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
