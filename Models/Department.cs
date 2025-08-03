namespace ITI_MVC.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string MangerName { get; set; }


		public List<Employee> employees { get; set; } = new List<Employee>();


	}
}
