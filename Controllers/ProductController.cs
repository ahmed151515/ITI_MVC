using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{

	public class ProductController : Controller
	{
		/*
		 * the method names a  Actions in Controller
		 * 1. cant't be private
		 * 2. can't be static
		 * 3. every Controller must end with word Controller ( ProductController )
		 * 4. can't be overload (excpet one case)
		 */

		// to call this action ( baseurl/product/showmsg ) not key sensitive
		//public string ShowMsg()
		//{
		//	return "hello from first action";
		//}

		///*
		// * what types action can returns
		// * .1 content "string"      ==> ContentResult
		// * .2 view "HTML"           ==> ViewResult
		// * .3 javascript            ==> JavaScriptResult
		// * .4 json                  ==> JsonResult
		// * .5 not found             ==> NotFoundResult
		// * .6 file                  ==> FileResult  
		// */

		//public ContentResult ShowMsgV2()
		//{
		//	// declare
		//	var result = new ContentResult();
		//	// set
		//	result.Content = "hello from first action";
		//	// return
		//	return result;
		//}

		//public ViewResult ShowView()
		//{
		//	// declare
		//	var result = new ViewResult();
		//	// set
		//	result.ViewName = "View1";
		//	// return
		//	return result;
		//}
		//public JsonResult ShowJson()
		//{
		//	var dict = new Dictionary<string, int>
		//	{
		//		{ "ahmed", 1 },
		//		{ "arafa", 2 }
		//	};

		//	// declare
		//	var result = new JsonResult(dict);
		//	// set

		//	// return
		//	return result;
		//}
		//// how call it (/product/showMix/11) with action parameter name id only
		//// query string way (/product/showMix?id=11) with any action parameter
		//public IActionResult ShowMix(int id)
		//{
		//	if (id % 2 == 0)
		//	{
		//		// declare
		//		var result = new ContentResult();
		//		// set
		//		result.Content = "hello from first action";
		//		// return
		//		return result;
		//	}
		//	else
		//	{
		//		// declare
		//		var result = new ViewResult();
		//		// set
		//		result.ViewName = "View1";
		//		// return
		//		return result;
		//	}
		//}

		//public ContentResult ShowMsgV3()
		//{


		//	return Content("hello from first action");
		//}

		//public ViewResult ShowViewV2()
		//{

		//	return View("View1");
		//}
		//public JsonResult ShowJsonV2()
		//{
		//	var dict = new Dictionary<string, int>
		//	{
		//		{ "ahmed", 1 },
		//		{ "arafa", 2 }
		//	};


		//	return Json(dict);
		//}

		public IActionResult Details(int id)
		{
			var prductsData = new ProductMockData();

			return View("details", prductsData.GetById(id));
		}
		public IActionResult index()
		{
			var prductsData = new ProductMockData();

			return View("index", prductsData.GetAll());
		}

	}
}
