using ITI_MVC.Models;
using ITI_MVC.Repository;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC;

public class Program
{
	public static void Main(string[] args)
	{
		//part 1 

		// DI (Dependency Injection) asp core support constructor only 

		// Controller --> Repository or (Service - Business layer)  --> Model -> DB

		/*
		 *  Most Companies Fallow Tow Principles
		 * 1. SOLID
		 * 2. IoC
		 */

		/*
		 * Service Lifetime in ASP.NET Core:
		 *
		 * 1. AddScoped:
		 *    - Creates ONE instance per HTTP Request.
		 *    - Same instance is shared across the whole request pipeline.
		 *    - Best for: DbContext, Repository, UnitOfWork.
		 *
		 * 2. AddTransient:
		 *    - Creates a NEW instance every time it is injected.
		 *    - Different instances even inside the same request.
		 *    - Best for: lightweight, stateless services (e.g., helpers, formatters).
		 *
		 * 3. AddSingleton:
		 *    - Creates ONE instance for the whole application lifetime.
		 *    - Same instance shared across all requests.
		 *    - Best for: caching, configuration, logging, services without state changes.
		 *
		 */

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		// 1— Built in service and already register in IOC Container (IConfiguration)
		// 2— Built in service but not register in IOC Container 
		builder.Services.AddControllersWithViews();
		builder.Services.AddSession();
		builder.Services.AddDbContext<AppDbContext>(o =>
				o.UseSqlServer(builder.Configuration.GetConnectionString("dev"))
			//.LogTo(Console.WriteLine, LogLevel.Information)
		);


		// 3— Custom service 
		builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
		builder.Services
			.AddScoped<IDepartmentRepository, DepartmentRepository>();

		builder.Services.AddScoped<ITemp, tempService>();
		// builder.Services.AddTransient<ITemp, tempService>();
		// builder.Services.AddSingleton<ITemp, tempService>();

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
			"default",
			"{controller=Home}/{action=Index}/{id:int?}"
		);
		app.MapControllerRoute(
			"defaultByName",
			"{controller=Home}/{action=Index}/{name:alpha?}"
		);
		app.MapControllerRoute(
			"emp",
			"emp/{action=Index}/{id?}",
			new
			{
				controller = "Employee"
			}
		);

		app.Run();
	}
}