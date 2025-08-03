using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
	public class StateManagementController : Controller
	{
		public IActionResult SetTempData()
		{

			TempData.Add("dateNow", DateTime.Now.ToString("f"));

			return Content("Data Saved");
		}
		public IActionResult GetTempData()
		{
			// normal read after reading key are deleted 
			//var value = TempData.Keys.Contains("dateNow") ? TempData["dateNow"].ToString() : "No Data Saved";

			// to get value without mark it deleted 
			var value = TempData.Keys.Contains("dateNow") ? TempData.Peek("dateNow").ToString() : "No Data Saved";
			return Content(value);
		}
		public IActionResult SetSession()
		{
			HttpContext.Session.SetString("date_now", DateTime.Now.ToString("f"));

			return Content("Session Data Saved");
		}
		public IActionResult GetSession()
		{
			var value = HttpContext.Session.GetString("date_now");
			return Content(value);
		}
		public IActionResult SetCookie()
		{

			Response.Cookies.Append("remembe_my", "true", new CookieOptions
			{ Expires = DateTimeOffset.Now.AddDays(15) });


			return Content("i will remembe you");
		}
		public IActionResult GetCookie()
		{
			var value = Request.Cookies.ContainsKey("remembe_my") ? "i know you" : "i don't see you before";

			return Content(value);
		}
	}
}
