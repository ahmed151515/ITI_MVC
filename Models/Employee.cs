using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITI_MVC.Models.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Models;

[Authorize]
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
	[Remote("CheckSalary", "Employee",
		ErrorMessage =
			"Salary must Be more than 7000 or equal")] // this  means a action in Emoloyee names cheackSalary take a salary as input 
	[Column(TypeName = "decimal(8,2)")]
	public decimal Salary { get; set; }

	[Required] public string Address { get; set; }

	[Display(Name = "Department")]
	[ForeignKey("Department")]
	public int Dept_Id { get; set; }

	public Department? Department { get; set; }
}