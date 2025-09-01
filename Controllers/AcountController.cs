using ITI_MVC.Models;
using ITI_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers;

public class AccountController(
	UserManager<ApplicationUser> userManager,
	SignInManager<ApplicationUser> signInManager)
	: Controller
{
	[Authorize]
	public async Task<IActionResult> Index()
	{
		var user = await userManager.GetUserAsync(User);
		ViewData["Roles"] = await userManager.GetRolesAsync(user);
		return View(user);
	}

	[AllowAnonymous]
	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(RegisterUserViewModel userModel)
	{
		if (ModelState.IsValid)
		{
			var user = new ApplicationUser
			{
				UserName = userModel.UserName,
				Address = userModel.Address
			};

			var result =
				await userManager.CreateAsync(user, userModel.Password);
			if (result.Succeeded)
			{
				// create cookie
				//Response.Cookies.Append()
				// await signInManager.SignInAsync(user, false);
				await userManager.AddToRoleAsync(user, "user");


				return RedirectToAction("login");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("",
						error.Description);
				}
			}
		}

		return View(userModel);
	}

	[Authorize(Roles = "Admin")]
	[HttpGet]
	public IActionResult AddAdmin()
	{
		return View();
	}

	[Authorize(Roles = "Admin")]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> AddAdmin(RegisterUserViewModel userModel)
	{
		if (ModelState.IsValid)
		{
			var user = new ApplicationUser
			{
				UserName = userModel.UserName,
				Address = userModel.Address
			};

			var result =
				await userManager.CreateAsync(user, userModel.Password);
			if (result.Succeeded)
			{
				// create cookie
				//Response.Cookies.Append()
				// await signInManager.SignInAsync(user, false);
				await userManager.AddToRoleAsync(user, "Admin");


				return RedirectToAction("login");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("",
						error.Description);
				}
			}
		}

		return View(userModel);
	}

	[AllowAnonymous]
	[HttpGet]
	public IActionResult Login(string ReturnUrl)
	{
		if (ReturnUrl != null)
		{
			TempData["ReturnUrl"] = ReturnUrl;
		}

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginUserViewModel userModel)
	{
		var returnUrl = TempData["ReturnUrl"];
		if (ModelState.IsValid)
		{
			var user = await userManager.FindByNameAsync(userModel.UserName);
			var result =
				await userManager.CheckPasswordAsync(user, userModel.Password);
			if (result)
			{
				await signInManager.SignInAsync(user, userModel.RememberMe);

				if (returnUrl != null)
				{
					return LocalRedirect(returnUrl.ToString());
				}

				return RedirectToAction("Index");
			}
		}

		ModelState.AddModelError("", "username or password is wrong");

		if (returnUrl != null)
		{
			TempData["ReturnUrl"] = returnUrl;
		}

		return View(userModel);
	}

	[Authorize]
	public async Task<IActionResult> Logout()
	{
		await signInManager.SignOutAsync();

		return RedirectToAction("Index", "Home");
	}

	[Authorize]
	public IActionResult TestClaims()
	{
		var userName = User.Identity.Name;
		// var userId =
		// 	User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
		// 		.Value;
		// return Content($"Id of {userName} is {userId}");

		var claims = User.Claims.Select(c => new
		{
			c.Type,
			c.Value
		});
		return Json(claims);
	}
}