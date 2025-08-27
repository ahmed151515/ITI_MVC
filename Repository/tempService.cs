namespace ITI_MVC.Repository;

public class tempService : ITemp
{
	public tempService()
	{
		id = Guid.NewGuid();
	}

	public Guid id { get; set; }
}