using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Controllers
{
	public class EmployeeController : Controller
	{

		ITIEntities context = new ITIEntities();
		public IActionResult Index()
		{
			var list = context.Employees.Include(e => e.Department).ToList();
			return View(list);
		}

		//  Returns a form view for creating a new Department
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var emp = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);

			ViewBag.Depts = context.Departments.Where(d => d.Id != emp.Dept_Id).Select(d => new
			{
				d.Id,
				d.Name
			}).ToList();

			return View(emp);
		}
		// Handles form submission and saves the new Department
		[HttpPost]
		// allow acsess from internal
		[ValidateAntiForgeryToken] // when you use Tag or HTML Hepler
		public IActionResult Edit(int id, Employee employee)
		{
			if (employee.Name != null && employee.Salary > 1000)
			{
				var emp = context.Employees.FirstOrDefault(e => e.Id == id);
				emp.Name = employee.Name;
				emp.Salary = employee.Salary;
				emp.Address = employee.Address;
				emp.Dept_Id = employee.Dept_Id;


				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return Edit(id);

		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Depts = DeptsDropList;
			return View();
		}
		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			if (employee.Salary >= 6000)
			{
				context.Employees.Add(employee);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Depts = DeptsDropList;

				ViewData["Error"] = $"salary Can't be less than 6000 current salary is {employee.Salary}";
				return View("Create", employee);
			}
		}

		public IEnumerable<SelectListItem> DeptsDropList => context.Departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
		//public IEnumerable<SelectListItem> DeptsDropList => new SelectList(context.Departments.Select(d => new { d.Name, d.Id }), "Id", "Name");
	}
}
