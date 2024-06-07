using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Infrastructure;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class UserBalanceModel : PageModel
    {
        private readonly ProfileManager profileManager;

        public UserBalanceModel()
        {
            var profileRepo = new ProfileRepository();
            profileManager = new ProfileManager(profileRepo);
        }

        public double UserBalance { get; set; }

        public string Username { get; set; }

        [BindProperty]
        public double Amount { get; set; }

        public void OnGet()
        {
            var userClaims = User.Claims;
			Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            UserBalance = profileManager.GetBalance(Username); 
        }

        public IActionResult OnPost()
        {
            var userClaims = User.Claims;
			string username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
		    var result = profileManager.AddToUserBalance(username, (double)Amount);

            if (result.Success)
            {
                return RedirectToPage("/UserBalance");
            }
            return Page();
        }
	}
}
