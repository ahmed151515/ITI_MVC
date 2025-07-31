namespace ITI_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// some custom Middelware
			//app.Use(async (httpContext, next) =>
			//{
			//	httpContext.Response.WriteAsync("Middelware 1\n");
			//	next.Invoke();
			//});
			//app.Use(async (httpContext, next) =>
			//{
			//	httpContext.Response.WriteAsync("Middelware 2\n");
			//	next.Invoke();

			//});

			//app.Run(async httpContext =>
			//{
			//	httpContext.Response.WriteAsync("Termiante\n");
			//});

			//app.Use(async (httpContext, next) =>
			//{
			//	httpContext.Response.WriteAsync("Middelware 3\n");
			//	next.Invoke();
			//});

			// Configure the HTTP request pipeline.
			// The order of middleware is very important.
			// For example, UseExceptionHandler must come before other middlewares
			// so it can handel exceptions thrown by them.

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
				);

			app.Run();
		}
	}
}
