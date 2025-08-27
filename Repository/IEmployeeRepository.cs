using ITI_MVC.Models;

namespace ITI_MVC.Repository;

public interface IEmployeeRepository
{
	public IQueryable<Employee> GetAll();

	public Employee GetById(int id);

	public Employee GetByIdWithDepartment(int id);

	public IQueryable<Employee> GetByDeptId(int DeptId);

	public void Add(Employee newEmp);

	public void Update(int id, Employee newEmp);

	public void Delete(int id);
}