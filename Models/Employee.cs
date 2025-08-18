using ITI_MVC.Models.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required]
		[MinLength(3, ErrorMessage = "The Name Can't Be Less Than 3 letters ")]
		[MaxLength(30)]
		[UniqueName(ErrorMsg = "Name arleady teken")]
		public string Name { get; set; }
		[Required]
		//[Range(7000, 20000)]
		[Remote("CheckSalary", "Employee", ErrorMessage = "Salary must Be more than 7000 or equal")] // this  means a action in Emoloyee names cheackSalary take a salary as input 
		public decimal Salary { get; set; }
		[Required]
		public string Address { get; set; }

		[ForeignKey("Department")]
		[Display(Name = "Department")]
		public int Dept_Id { get; set; }

		public Department? Department { get; set; }



	}
}
