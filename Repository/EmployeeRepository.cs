using ITI_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Repository;

public class EmployeeRepository : IEmployeeRepository
{
	private AppDbContext _context; //= new();

	public EmployeeRepository(AppDbContext context)
	{
		_context = context;
	}

	public IQueryable<Employee> GetAll()
	{
		var emps = _context.Employees;
		return emps;
	}

	public Employee GetById(int id)
	{
		var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
		return emp;
	}

	public Employee GetByIdWithDepartment(int id)
	{
		var emp = _context.Employees.Include(e => e.Department).SingleOrDefault(e => e.Id == id);
		return emp;
	}

	public IQueryable<Employee> GetByDeptId(int DeptId)
	{
		var emps = _context.Employees.Where(e => e.Dept_Id == DeptId);
		return emps;
	}

	public void Add(Employee newEmp)
	{
		_context.Employees.Add(newEmp);
		_context.SaveChanges();
	}

	public void Update(int id, Employee newEmp)
	{
		var oldEmp = GetById(id);
		oldEmp.Name = newEmp.Name;
		oldEmp.Address = newEmp.Address;
		oldEmp.Salary = newEmp.Salary;
		oldEmp.Dept_Id = newEmp.Dept_Id;

		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var emp = GetById(id);

		_context.Employees.Remove(emp);

		_context.SaveChanges();
	}
}