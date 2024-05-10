using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ProfileManager _profileManager;

        public ProfileModel(ProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        public Logic.Profiles Profile { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve the current user's email from Claims
            var emailClaim = User.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
            {
                // If email claim is not found, return an unauthorized result or handle the situation accordingly
                return Unauthorized();
            }

            // Retrieve the profile data for the current user's email
            Profile = _profileManager.GetProfileByEmail(emailClaim.Value);

            if (Profile == null)
            {
                // If profile is not found, handle the situation accordingly
                return NotFound();
            }

            return Page();
        }
    }
}
