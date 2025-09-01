using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel;

public class LoginUserViewModel
{
	[Required]
	[MinLength(3)]
	[MaxLength(20)]
	public string UserName { get; set; }

	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	public bool RememberMe { get; set; }
}