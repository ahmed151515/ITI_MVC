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


		public IActionResult Details(int id)
		{
			var emp = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
			return View(emp);
		}
		public IActionResult Card(int id)
		{
			var emp = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
			return PartialView("_EmployeeCardPartial", emp);
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
		public IActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				var emp = context.Employees.FirstOrDefault(e =>

				 e.Id == employee.Id
					);
				emp.Name = employee.Name;
				emp.Salary = employee.Salary;
				emp.Address = employee.Address;
				emp.Dept_Id = employee.Dept_Id;


				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return Edit(employee.Id);

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
			if (ModelState.IsValid)
			{
				try
				{
					context.Employees.Add(employee);
					context.SaveChanges();
					return RedirectToAction("Index");
				}
				catch
				{
					ModelState.AddModelError("", "samething is failure try later");
				}
			}


			ViewBag.Depts = DeptsDropList;

			return View("Create", employee);



		}

		public JsonResult CheckSalary(decimal Salary)
		{
			if (Salary >= 7000)
			{
				return Json(true);
			}
			return Json(false);
		}

		//public IEnumerable<SelectListItem> DeptsDropList => context.Departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));

		public IEnumerable<SelectListItem> DeptsDropList => new SelectList(context.Departments.Select(d => new { d.Name, d.Id }), "Id", "Name");


	}
}
