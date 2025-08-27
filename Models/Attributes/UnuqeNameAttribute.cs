using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Models.Attributes;

public class UniqueNameAttribute : ValidationAttribute
{
	public string ErrorMsg { get; set; }

	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		//if (value is not string val || string.IsNullOrWhiteSpace(val))
		//{ 
		//	return new ValidationResult("Name must not empty");
		//}
		if (value is string val && validationContext.ObjectInstance is Employee emp)
		{
			using var context = new AppDbContextWithoutConstructor();

			var res = context.Employees.FirstOrDefault(e => e.Id != emp.Id && e.Name == val);

			if (res == null)
			{
				return ValidationResult.Success;
			}
		}

		return new ValidationResult(ErrorMsg);
		//return base.IsValid(value, validationContext);
	}
}