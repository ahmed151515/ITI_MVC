using ITI_MVC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers;

public class FiltersController : Controller
{
	[Authorize]
	public IActionResult IsAuthorize()
	{
		return Content("True");
	}

	[MyFilter]
	public IActionResult TestMyFilter()
	{
		Console.WriteLine("Executing");
		return Content("Result");
	}
}