using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Logic;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;

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

        public async Task<IActionResult> OnPostUpdateProfile(IFormFile profilePicture, string username, string email)
        {
            var userClaims = User.Claims;
            string oldUsername = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            User oldUser = userManager.GetUserByUsernameFromDb(oldUsername);

            if (oldUser != null)
            {
                User newUser = new User
                (
                    oldUser.UserID,
                    username,
                    oldUser.Password,
                    email,
                    oldUser.UserType,
                    oldUser.Birthday,
                    oldUser.FavGenre,
                    oldUser.ProfilePictureName,
                    oldUser.ProfilePictureData,
                    oldUser.ProfilePictureContentType
                );

                if (profilePicture != null && profilePicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await profilePicture.CopyToAsync(memoryStream);
                        newUser.ProfilePictureData = memoryStream.ToArray();
                        newUser.ProfilePictureContentType = profilePicture.ContentType;
                        newUser.ProfilePictureName = profilePicture.FileName;
                    }
                }
                
                var result = userManager.Update(newUser, oldUser);
                
                if (result.Success)
                {
                    // Updates the claims in the current user identity
                    await UpdateUserClaims(newUser);
                    return RedirectToPage();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found.");
            }

            return Page();
        }

        private async Task UpdateUserClaims(User newUser)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var currentPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Remove existing claims
            claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.Name));
            claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.Email));

            // Add updated claims
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, newUser.Username));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, newUser.Email));

            await HttpContext.SignInAsync(currentPrincipal);
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
