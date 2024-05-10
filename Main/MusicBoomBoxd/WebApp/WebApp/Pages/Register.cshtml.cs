using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using WebApp.Models;
using Infrastructure.DTOs;
using Infrastructure;
using Microsoft.AspNetCore.Http;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private static UserManager userManager;
        private static UserRepository userRepository;

        // Added a property for handling file upload
        [BindProperty]
        public IFormFile ProfilePicture { get; set; }

        // Binds the User object
        [BindProperty]
        public Models.User User { get; set; }

        public RegisterModel()
        {
            LoadUsers loadUsers = new LoadUsers(userRepository);
            userManager = new UserManager(loadUsers);
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

                UserDTO newUser = new UserDTO(User.UserName, User.Password, User.Email, "Regular_User");

                if (userManager.SendToTheDb(newUser))
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
