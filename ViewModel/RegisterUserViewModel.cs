using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel;

public class RegisterUserViewModel
{
	[Required]
	[MinLength(3)]
	[MaxLength(20)]
	public string UserName { get; set; }

	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; }

	[Required] public string Address { get; set; }
}