using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Infrastructure;
using Logic;

namespace WebApp.Pages
{
    [Authorize(Roles = "Regular")]
    public class UpgradeUserAccountModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly ProfileManager _profileManager;

        public string Username { get; private set; }

        public UpgradeUserAccountModel()
        {
            IUserRepository iUserRep = new UserRepository();
            IProfileRepository iProfRep = new ProfileRepository();
            ValidateUser valUser = new ValidateUser(iUserRep);
            _userManager = new UserManager(iUserRep, iProfRep, valUser);
            _profileManager = new ProfileManager(iProfRep);
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUpgradeAccountMusicianAsync()
        {
            var userClaims = User.Claims;
            string username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var profileID = _profileManager.GetProfileIDByUsername(username);
            var currentUserBalance = _profileManager.GetBalance(username);
            double totalUpgradeCostMusician = 10.00;

            if (currentUserBalance < totalUpgradeCostMusician)
            {
                ModelState.AddModelError(string.Empty, "Looks like you have got insufficient balance to complete the transaction. :( ");
                return Page();
            }

            User user = _userManager.GetUserByUsernameFromDb(username);
            if (user != null)
            {
                Result resultMusician = _userManager.UpgradeToMusician(user);

                if (resultMusician.Success)
                {
                    // Update user's role claim to Musician
                    var identity = (ClaimsIdentity)User.Identity;
                    var roleClaim = identity.FindFirst(ClaimTypes.Role);
                    if (roleClaim != null)
                    {
                        identity.RemoveClaim(roleClaim);
                    }
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Musician"));
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                    return RedirectToPage("/Profile");
                }
				else
                {
                    // Handle the failure scenario (e.g., show an error message)
                    return Page();
                }

            }
            else
            {
                // Handle the failure scenario (e.g., show an error message)
                return Page();
            }
        }

		public async Task<IActionResult> OnPostUpgradeAccountCriticAsync()
		{
			var userClaims = User.Claims;
			string username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			var profileID = _profileManager.GetProfileIDByUsername(username);
			var currentUserBalance = _profileManager.GetBalance(username);
			double totalUpgradeCostCritic = 40.00;

			if (currentUserBalance < totalUpgradeCostCritic)
			{
				ModelState.AddModelError(string.Empty, "Looks like you have got insufficient balance to complete the transaction. :( ");
				return Page();
			}

			User user = _userManager.GetUserByUsernameFromDb(username);

			if (user != null)
			{
				
				Result resultCritic = _userManager.UpgradeToCritic(user);

				if (resultCritic.Success)
				{
					// Update user's role claim to Critic
					var identity = (ClaimsIdentity)User.Identity;
					var roleClaim = identity.FindFirst(ClaimTypes.Role);
					if (roleClaim != null)
					{
						identity.RemoveClaim(roleClaim);
					}
					identity.AddClaim(new Claim(ClaimTypes.Role, "Critic"));
					await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

					return RedirectToPage("/Profile");
				}
				else
				{
					// Handle the failure scenario (e.g., show an error message)
					return Page();
				}

			}
			else
			{
				// Handle the failure scenario (e.g., show an error message)
				return Page();
			}
		}
	}
}
