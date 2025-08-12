namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// HTML helper work in farmework  and core

			/*
			 * lossly type
			 * order of search of value is
			 * 1. ViewData
			 * 2. VeiwBag
			 * 3. Model as Proprety
			 * 4. null
			 * 
			 * Strong type must the view strong type 
			 * end with for
			 */

			// Tag Helper core only
			/*
			 * 
			 */

			// topic 2
			// layout


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
