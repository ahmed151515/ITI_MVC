using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
	public AppDbContext()
	{
	}

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Employee> Employees { get; set; }
	public DbSet<Department> Departments { get; set; }

	protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer(
				"Data Source=.;Initial Catalog=ITI_MVC;User ID=sa;Password=SqlServer1;Trust Server Certificate=True")
			//.LogTo(Console.WriteLine, LogLevel.Information)
			;
	}
}