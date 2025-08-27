using ITI_MVC.Models;

namespace ITI_MVC.Repository;

public interface IDepartmentRepository
{
	public IQueryable<Department> GetAll();


	public Department GetById(int id);


	public void Add(Department newDept);


	public void Update(int id, Department newDept);


	public void Delete(int id);
}