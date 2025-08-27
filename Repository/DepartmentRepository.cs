using ITI_MVC.Models;

namespace ITI_MVC.Repository;

public class DepartmentRepository : IDepartmentRepository
{
	private AppDbContext _context; //= new();

	public DepartmentRepository(AppDbContext context)
	{
		_context = context;
	}

	public IQueryable<Department> GetAll()
	{
		var depts = _context.Departments;
		return depts;
	}

	public Department GetById(int id)
	{
		var dept = _context.Departments.SingleOrDefault(e => e.Id == id);
		return dept;
	}

	public void Add(Department newDept)
	{
		_context.Departments.Add(newDept);
		_context.SaveChanges();
	}

	public void Update(int id, Department newDept)
	{
		var oldDept = GetById(id);
		oldDept.Name = newDept.Name;
		oldDept.MangerName = newDept.MangerName;


		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var dept = GetById(id);

		_context.Departments.Remove(dept);

		_context.SaveChanges();
	}
}