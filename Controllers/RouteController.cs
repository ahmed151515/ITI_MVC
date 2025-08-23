using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
	public class RouteController : Controller
	{
		public IActionResult Index(string name, int? id)
		{
			return Content($"hello {(id == null ? name : id)}");
		}
		//[Route("show/{msg:alpha=msg}")] // only way to access this route
		[HttpGet("show/{msg:alpha=msg}")]
		public IActionResult ShowMsg(string msg)
		{
			return Content(msg);
		}
	}
}
