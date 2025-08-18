namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Part 1
			// validation
			/*
			 * type of validation 
			 * .1 Client Side (JS)
			 * .2 Server Side
			 * .3 SQL Server (Constraint)
			 */
			// prat 2
			/*
			 * when create custom validation 
			 * .1 not found built in attribute (like less than or greater than only)
			 * .2 validate based on DB
			 * 
			 * Types
			 * .1 validation attribute 
			 * .2 remote (MVC only)
			 */

			// ModelMataData when you database first

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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
