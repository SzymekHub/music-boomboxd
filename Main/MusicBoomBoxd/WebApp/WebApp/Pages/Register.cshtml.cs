using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using WebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly UserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;

        // Binds the User object
        [BindProperty]
        public Models.User User { get; set; }

        // Added a property for handling file upload
        [BindProperty]
        public IFormFile ProfilePicture { get; set; }

        public RegisterModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handles file upload
            if (ProfilePicture != null)
            {
                string filePath = Path.Combine(_environment.WebRootPath, "img", ProfilePicture.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(fileStream);
                }

                User.ProfilePictureContentType = filePath;
            }
            //saves user to the Database
            UserDTO newUser = new UserDTO(User.UserName, User.Password, User.Email, User.UserType, User.Birthday, User.FavGenre, User.ProfilePictureName, User.ProfilePictureData, User.ProfilePictureContentType);
            
            // validate if user already exists.It could go wrong
            // Change the naming for more functionaity 
            if (_userManager.SendUserToTheDb(newUser))
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
