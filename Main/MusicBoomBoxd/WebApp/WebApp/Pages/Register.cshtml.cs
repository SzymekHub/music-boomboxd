using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using WebApp.Models;
using Infrastructure.DTOs;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly UserRepository _userRepository;


        // Added a property for handling file upload
        [BindProperty]
        public IFormFile ProfilePicture { get; set; }

        // Binds the User object
        [BindProperty]
        public Models.User User { get; set; }
        public Models.Profile profile { get; set; }

        public RegisterModel(UserManager userManager, UserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Check if a profile picture is uploaded
                if (ProfilePicture != null && ProfilePicture.Length > 0)
                {
                    // Convert profile picture to byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        ProfilePicture.CopyTo(memoryStream);
                        User.ProfilePictureData = memoryStream.ToArray();
                        User.ProfilePictureContentType = ProfilePicture.ContentType;
                        User.ProfilePictureName = ProfilePicture.FileName;
                    }
                }

                ProfileDTO newProfile = new ProfileDTO(Profiles.);
                UserDTO newUser = new UserDTO(User.UserName, User.Password, User.Email, User.UserType, User.Birthday, User.FavGenre, User.ProfilePictureName, User.ProfilePictureData, User.ProfilePictureContentType);

                if (_userManager.SendToTheDb(newProfile,newUser))
                {
                    return RedirectToPage("/Index");
                }
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
