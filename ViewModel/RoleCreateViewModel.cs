using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel;

public class RoleViewModel
{
	[Required] public string RoleName { get; set; }
}