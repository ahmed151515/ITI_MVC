using ITI_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers;

public class LifeTimeController(ITemp temp, IConfiguration configuration)
	: Controller
{
	public IActionResult
		Index([FromServices] ITemp methodTemp) // injection method ask IoC
	{
		ViewBag.Id = temp.id;
		var appName = configuration.GetSection("AppName").Value;
		return View(model: appName);
	}
}