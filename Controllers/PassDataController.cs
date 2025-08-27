using ITI_MVC.Models;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers;

public class PassDataController : Controller
{
	private AppDbContextWithoutConstructor context = new();

	public IActionResult TestViewData()
	{
		var Emp = context.Employees.FirstOrDefault();
		var dateNow = DateTime.Now.ToString("dddd-MMMM-yyyyy");
		var numOfEmployees = context.Employees.Count();
		ViewData.Add(nameof(dateNow), dateNow);
		ViewData.Add(nameof(numOfEmployees), numOfEmployees);
		return View(Emp);
	}

	public IActionResult TestViewBag()
	{
		var Emp = context.Employees.FirstOrDefault();
		var dateNow = DateTime.Now.ToString("dddd-MMMM-yyyyy");
		var numOfEmployees = context.Employees.Count();
		ViewBag.dateNow = dateNow;
		ViewBag.numOfEmployees = numOfEmployees;

		return View(Emp);
	}

	public IActionResult TestViewBagModel()
	{
		var Emp = context.Employees.FirstOrDefault();
		var dateNow = DateTime.Now.ToString("dddd-MMMM-yyyy");
		var numOfEmployees = context.Employees.Count();

		var ViewModel = new EmployeeAndMessageAndEmployeeCountViewModel(Emp, numOfEmployees, dateNow);

		return View(ViewModel);
	}
}