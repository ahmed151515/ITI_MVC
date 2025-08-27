using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Models;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Employee> Employees { get; set; }
	public DbSet<Department> Departments { get; set; }
}

public class AppDbContextWithoutConstructor : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer(
				"Data Source=.;Initial Catalog=ITI_MVC;User ID=sa;Password=SqlServer1;Trust Server Certificate=True")
			//.LogTo(Console.WriteLine, LogLevel.Information)
			;
	}

	public DbSet<Employee> Employees { get; set; }
	public DbSet<Department> Departments { get; set; }
}