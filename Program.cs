namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// part 1
			// Model binding: : Map Action Parametere with request data (Form —Query String —RouteData)
			// Types

			// Bind Premitive type
			// Bind Collection(Dictionary)
			// Bind Complex/Custom type

			// part 2


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
