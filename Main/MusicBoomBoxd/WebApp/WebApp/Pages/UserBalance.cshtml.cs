using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class UserBalanceModel : PageModel
    {
		public readonly IPasswordHasher _passwordHasher;
		public readonly IProfileRepository _profileRepository;
		public readonly ProfileManager _profileManager;
		public readonly IUserRepository _userRepository;
		private readonly IValidateUser _validateUsers;

		public UserBalanceModel(IPasswordHasher passwordHasher, IUserRepository userRepository, IValidateUser validateUsers, IProfileRepository profileRepository)
        {
			_passwordHasher = passwordHasher;
			_userRepository = userRepository;
			_validateUsers = validateUsers;
			_profileRepository = profileRepository;
			_profileManager = new ProfileManager(profileRepository, userRepository, validateUsers, passwordHasher);
		}

		public double UserBalance { get; set; }

        public string Username { get; set; }

        [BindProperty]
        public double Amount { get; set; }

        public void OnGet()
        {
            var userClaims = User.Claims;
			Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            UserBalance = _profileManager.GetBalance(Username); 
        }

        public IActionResult OnPost()
        {
            var userClaims = User.Claims;
			string username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
		    var result = _profileManager.AddToUserBalance(username, (double)Amount);

            if (result.Success)
            {
                return RedirectToPage("/UserBalance");
            }
            return Page();
        }
	}
}
