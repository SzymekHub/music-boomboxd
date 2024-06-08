using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Logic;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Pages
{
	[Authorize]
	public class ProfileModel : PageModel
	{
		private readonly UserManager userManager;

		public string Username { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public byte[] ProfilePictureData { get; set; }
		public string ProfilePictureContentType { get; set; }

		public ProfileModel()
		{
			IUserRepository iUserRep = new UserRepository();
			IProfileRepository iPortRep = new ProfileRepository();
			ValidateUser ValUser = new ValidateUser(iUserRep);
			userManager = new UserManager(iUserRep, ValUser);
		}

		// This initializes user information
		public void OnGet()
		{
			var userClaims = User.Claims;
			Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
			Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
			Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
			
			var user = userManager.GetUserByUsernameFromDb(Username);
			if (user != null)
			{
				ProfilePictureData = user.ProfilePictureData;
				ProfilePictureContentType = user.ProfilePictureContentType;
			}
		}

		public IActionResult OnPostDeleteAccount()
		{
			var userClaims = User.Claims;
			string username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			User user = userManager.GetUserByUsernameFromDb(username);
			if (user != null)
			{
				Result result = userManager.Remove(user);
				if (result.Success)
				{
					return RedirectToPage("/Logout");
				}
				else
				{
					ModelState.AddModelError(string.Empty, result.Message);
					userClaims = User.Claims;
					Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
					Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
					Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
					return Page();
				}
			}
			else
			{
				//ModelState here
				return Page();
			}
		}

		public IActionResult OnPostUpgradeAccount()
		{
			return RedirectToPage("/UpgradeAccount");
		}
	}
}
