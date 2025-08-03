using ITI_MVC.Models;

namespace ITI_MVC.ViewModel
{
	public class EmployeeAndMessageAndEmployeeCountViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Salary { get; set; }
		public string Address { get; set; }
		public int EmployeeCount { get; set; }
		public string DateNow { get; set; }

		public EmployeeAndMessageAndEmployeeCountViewModel(Employee employee, int employeeCount, string dateNow)
		{
			Id = employee.Id;
			Name = employee.Name;
			Salary = employee.Salary;
			Address = employee.Address;
			EmployeeCount = employeeCount;
			DateNow = dateNow;
		}
	}
}
