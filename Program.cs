using ITI_MVC.Models;
using ITI_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC;

public class Program
{
	public static void Main(string[] args)
	{
		/*
		 * Topics:
		 *	1. Filters
		 *	2. Security
		 *  3. Publish (dll)
		 */

		/*
		 * Filters: some code execute ( Before - After - During ) Action
		 * Built in filters:
		 *		Authorization
		 *		Response Cache
		 */

		/*
		 * Security in ASP.NET Core Identity
		 *
		 *  - Identity Package (Microsoft.AspNetCore.Identity.EntityFrameworkCore)
		 *    Provides EF Core code-first setup for Authentication & Authorization
		 *
		 *  - Default tables:
		 *      * AspNetUsers        -> store Users
		 *      * AspNetRoles        -> store Roles
		 *      * AspNetUserRoles    -> M:M relationship (User ↔ Role)
		 *      * AspNetUserClaims   -> 1:M relationship (User ↔ Claims)
		 *      * AspNetRoleClaims   -> 1:M relationship (Role ↔ Claims)
		 *
		 *  - Claims:
		 *      * Represent extra information about a User or Role
		 *      * Stored as Key/Value pairs (ClaimType, ClaimValue)
		 *      * Examples:
		 *          - UserClaim: ("DateOfBirth", "2000-01-01")
		 *          - UserClaim: ("Permission", "CanEditCourse")
		 *          - RoleClaim: ("Permission", "CanDeleteAnyCourse")
		 *
		 *  - Relationships:
		 *      * One User → Many Claims
		 *      * One Role → Many Claims
		 *      * One User → Many Roles (via AspNetUserRoles)
		 *
		 *  - Extensible:
		 *      * Can add custom fields to ApplicationUser
		 *      * Can define policies that depend on Claims (UserClaims or RoleClaims)
		 *
		 *  - Authentication supported:
		 *      * Cookie-based Authentication (default in MVC apps)
		 *      * Token-based Authentication (JWT)
		 *
		 *  - Claim-based Authorization:
		 *      * Instead of only checking Role (e.g., [Authorize(Roles="Admin")])
		 *      * You can check for specific Claim (e.g., [Authorize(ClaimType="Permission", ClaimValue="CanEditCourse")])
		 *      * Policies can be defined in Program.cs:
		 *          services.AddAuthorization(options =>
		 *          {
		 *              options.AddPolicy("EditCoursePolicy",
		 *                  policy => policy.RequireClaim("Permission", "CanEditCourse"));
		 *          });
		 *      * Then used in Controller:
		 *          [Authorize(Policy = "EditCoursePolicy")]
		 */

		// layers Controller => Service => Repository => AppDbContext => DB
		// - Repository: 
		//     * Responsible for basic data access (CRUD)
		//     * Can return IQueryable<Entity> to allow composition
		//
		// - Service:
		//     * Contains business logic
		//     * Consumes Repository
		//     * Executes final queries (materializes IQueryable)
		//     * Returns ViewModel or ready-to-use data to Controller

		/*
		 * table  | Class        | Service    | Repository | DbContext
		 * User   | IdentityUser | UserManger | UserStore  | IdentityDbContext
		 * Role   | IdentityRole | RoleManger | RoleStore  | IdentityDbContext
		 */

		/*
		 * 1- Install packages microsoft.EntityFrameworkCore.sqlserver
		 * 2- Microsoft.AspNetCore. Identity. EntityFrameworkCore
		 * 3- create class applicationUser inherit from IdentityUser
		 * 4- change context inherit from DbContext to IdentityDbContext
		 * 5- Migration
		 */
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		// 1— Built in service and already register in IOC Container (IConfiguration)
		// 2— Built in service but not register in IOC Container 
		builder.Services.AddControllersWithViews(
			//conf=>conf.Filters.Add() // pipeline filter apply for all application  
		);
		builder.Services.AddSession();
		builder.Services.AddDbContext<AppDbContext>(o =>
				o.UseSqlServer(builder.Configuration.GetConnectionString("dev"))
			//.LogTo(Console.WriteLine, LogLevel.Information)
		);

		builder.Services
			.AddIdentity<ApplicationUser, IdentityRole>(option =>
			{
				option.Password.RequireLowercase = false;
				option.Password.RequireNonAlphanumeric = false;
				option.Password.RequireUppercase = false;
			}) // add classes and Mangers
			.AddEntityFrameworkStores<AppDbContext>() // add Stores 
			// must register the AppDbContext first
			;


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

		app.UseAuthentication(); // must add 

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