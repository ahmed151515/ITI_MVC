using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Models
{
	public class Department
	{
		public int Id { get; set; }

		[Display(Name = "Department Name")]
		//[DataType(dataType: DataType.Password)]
		public string Name { get; set; }
		[Display(Name = "Department Manger")]
		public string MangerName { get; set; }


		public List<Employee> employees { get; set; } = new List<Employee>();


	}
}
