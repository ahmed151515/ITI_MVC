using Microsoft.AspNetCore.Mvc.Filters;

namespace ITI_MVC.Filters;

public class MyFilterAttribute : Attribute, IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		Console.WriteLine("Before");
		Thread.Sleep(1000);
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
		Thread.Sleep(1000);
		Console.WriteLine("After");
	}
}