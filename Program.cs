namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//part 1
			/*
			 Pass Data From Action C# To View HTML
				1- Model
				2- ViewData
				3- ViewBag
				4- ViewModel
			*/

			// part 2
			/*
			 StateManagement 
				1- Tempdata you can use it until it read or session end its Storge in Cokies
				2- Session 
				3- Cookies 
				4- QueryString self study
				5- HiddenField self study
			 */

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews()
				.AddSessionStateTempDataProvider() // to save tempData in Server
				;

			builder.Services.AddSession();

			var app = builder.Build();



			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}



			app.UseStaticFiles();

			app.UseRouting();


			app.UseAuthorization();

			app.UseSession();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
				);

			app.Run();
		}
	}
}
