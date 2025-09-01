using ITI_MVC.Models;
using ITI_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_MVC.Controllers;

[Authorize]
public class EmployeeController : Controller
{
	// private AppDbContext _context = new();

	private IEmployeeRepository
		_employeeRepository; //= new EmployeeRepository();

	private IDepartmentRepository
		_departmentRepository; //= new DepartmentRepository();

	public EmployeeController(IEmployeeRepository employeeRepository,
		IDepartmentRepository departmentRepository)
	{
		_departmentRepository = departmentRepository;
		_employeeRepository = employeeRepository;
	}

	public IActionResult Index()
	{
		var list = _employeeRepository.GetAll().ToList();
		return View(list);
	}


	public IActionResult Details(int id)
	{
		var emp = _employeeRepository.GetById(id);
		return View(emp);
	}

	public IActionResult Card(int id)
	{
		var emp = _employeeRepository.GetByIdWithDepartment(id);
		return PartialView("_EmployeeCardPartial", emp);
	}

	//  Returns a form view for creating a new Department
	[HttpGet]
	public IActionResult Edit(int id)
	{
		var emp = _employeeRepository.GetByIdWithDepartment(id);

		ViewBag.Depts = DeptsDropList;

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
			_employeeRepository.Update(employee.Id, employee);
			return RedirectToAction("Index");
		}

		return View("Edit", employee);
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
			try
			{
				_employeeRepository.Add(employee);
				return RedirectToAction("Index");
			}
			catch
			{
				ModelState.AddModelError("", "samething is failure try later");
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

	public IEnumerable<SelectListItem> DeptsDropList =>
		new SelectList(_departmentRepository.GetAll().AsEnumerable(), "Id",
			"Name");
}