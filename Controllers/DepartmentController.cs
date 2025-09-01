using ITI_MVC.Models;
using ITI_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_MVC.Controllers;

public class DepartmentController : Controller
{
	// private AppDbContext context = new();

	private IDepartmentRepository _departmentRepository; //= new DepartmentRepository();
	private IEmployeeRepository _employeeRepository; //= new EmployeeRepository();

	public DepartmentController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
	{
		_departmentRepository = departmentRepository;
		_employeeRepository = employeeRepository;
	}

	public IActionResult Employees(int dept_Id)
	{
		var emps = _employeeRepository.GetByDeptId(dept_Id).ToList();
		return PartialView("_EmployeesPartial", emps);
	}


	public IActionResult Index()
	{
		var data = _departmentRepository.GetAll();


		return View("Index", data);
	}

	public IActionResult Details(int id)
	{
		var data = _departmentRepository.GetById(id);


		return View(data);
	}

	public IActionResult DropDownList()
	{
		var data = new SelectList(_departmentRepository.GetAll().AsEnumerable(), "Id", "Name");


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
			_departmentRepository.Add(department);

			return RedirectToAction("Index");
		}
		else
		{
			department.Name = "can't name be come null";
			return View("new", department);
		}
	}
}