namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//part 1 

			// pratial View

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
				pattern: "{controller=Home}/{action=Index}/{id:int?}"
				);
			app.MapControllerRoute(
				name: "defaultByName",
				pattern: "{controller=Home}/{action=Index}/{name:alpha?}"
				);
			app.MapControllerRoute(
				name: "emp",
				pattern: "emp/{action=Index}/{id?}",
				new
				{
					controller = "Employee"
				}
				);

			app.Run();
		}
	}
}
