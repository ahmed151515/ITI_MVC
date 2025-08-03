using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Salary { get; set; }
		public string Address { get; set; }

		[ForeignKey("Department")]
		public int Dept_Id { get; set; }
		public Department Department { get; set; }

		

	}
}
