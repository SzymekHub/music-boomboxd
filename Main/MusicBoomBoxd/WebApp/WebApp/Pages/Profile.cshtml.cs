using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Logic;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public readonly UserManager _userManager;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IProfileRepository _profileRepository;
        public readonly IUserRepository _userRepository;
        private readonly IValidateUser _validateUsers;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public byte[] ProfilePictureData { get; set; }
        public string ProfilePictureContentType { get; set; }

        public ProfileModel(IPasswordHasher passwordHasher, IUserRepository userRepository, IValidateUser validateUsers, IProfileRepository profileRepository)
        {
            _userManager = new UserManager(passwordHasher, userRepository, validateUsers, profileRepository);
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _validateUsers = validateUsers;
            _profileRepository = profileRepository;
        }

        // This initializes user information
        public void OnGet()
        {
            LoadUserData();
        }
        
        public async Task<IActionResult> OnPostUpdateProfile(IFormFile profilePicture, string username, string email)
        {
            var userClaims = User.Claims;
            string oldUsername = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            User oldUser = _userManager.GetUserByUsernameFromDb(oldUsername);

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

                var Errors = _validateUsers.ValidateUsersWEB(newUser);

                if (Errors.Count > 0)
                {
                    foreach (var error in Errors)
                    {
                        ModelState.AddModelError(string.Empty, string.Join(", ", error.Value));
                    }
                    LoadUserData();
                    return Page();
                }

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
                else
                {
                    var user = _userManager.GetUserByUsernameFromDb(oldUsername);
                    if (user != null)
                    {
                        newUser.ProfilePictureName = user.ProfilePictureName;
                        newUser.ProfilePictureData = user.ProfilePictureData;
                        newUser.ProfilePictureContentType = user.ProfilePictureContentType;
                    }
                }

                var result = _userManager.Update(newUser);

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

            LoadUserData();
            return Page();
        }
        private void LoadUserData()
        {
            var userClaims = User.Claims;
            Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var user = _userManager.GetUserByUsernameFromDb(Username);
            if (user != null)
            {
                ProfilePictureData = user.ProfilePictureData;
                ProfilePictureContentType = user.ProfilePictureContentType;
            }
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

            User user = _userManager.GetUserByUsernameFromDb(username);
            if (user != null)
            {
                Result result = _userManager.Remove(user);
                if (result.Success)
                {
                    return RedirectToPage("/Logout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    LoadUserData();
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                LoadUserData();
                return Page();
            }
        }

        public IActionResult OnPostUpgradeAccount()
        {
            return RedirectToPage("/UpgradeUserAccount");
        }
    }
}
