using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Infrastructure;
using WebApp.Pages.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        public UserManager _userManager { get; }
        private IWebHostEnvironment _environment;


        // Binds the User object
        [BindProperty]
        public RegisterUser RegiUser { get; set; }

        // Added a property for handling file upload
        [BindProperty]
        [Display(Name = "Profile Picture"), Required]
        public IFormFile ProfilePicture { get; set; }

        public RegisterModel(UserManager userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
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
            else
            {
                try
                {
                    string ProfilePictureName = ProfilePicture.FileName;
                    string filePath = Path.Combine(_environment.WebRootPath, "img", ProfilePicture.FileName);
                    string ProfilePictureContentType = ProfilePicture.ContentType;
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ProfilePicture.CopyTo(fileStream);
                    }
                }
                catch (Exception ex)
                {

                }
                
            }
            //saves user to the Database
            UserDTO newUser = new UserDTO(RegiUser.Name, RegiUser.Password, RegiUser.Email, RegiUser.UserType, RegiUser.Birthday, RegiUser.FavGenre, RegiUser.ProfilePictureName, RegiUser.ProfilePictureData, RegiUser.ProfilePictureContentType);

            // validate if user already exists.It could go wrong
            // Change the naming for more functionaity 

            var result = _userManager.SendUserToTheDbWEB(newUser);
            
            if (result.Success)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                if (result.Errors != null)
                {
                    foreach (var errorKey in result.Errors)
                    {
                        foreach (var errorValue in errorKey.Value)
                        {
                            ModelState.AddModelError($"User.{errorKey.Key}", errorValue);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
                return Page();
            }

        }
    }
}
