using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers;

[Authorize(Roles = "Admin")]
public class RoleController(RoleManager<IdentityRole> roleManager) : Controller
{
	// GET
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(RoleViewModel roleViewModel)
	{
		if (ModelState.IsValid)
		{
			var role = new IdentityRole
			{
				Name = roleViewModel.RoleName
			};

			var result = await roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(nameof(roleViewModel.RoleName),
						error.Description);
				}
			}
		}

		return View(roleViewModel);
	}
}