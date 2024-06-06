
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            try
            {
                if (ProfilePicture != null)
                {
                    RegiUser.ProfilePictureName = ProfilePicture.FileName;
                    RegiUser.ProfilePictureContentType = ProfilePicture.ContentType;

                    using (var memoryStream = new MemoryStream())
                    {
                        await ProfilePicture.CopyToAsync(memoryStream);
                        RegiUser.ProfilePictureData = memoryStream.ToArray();
                    }
                }
               
                //saves user to the Database
                User newUser = new User(
                        RegiUser.Name,
                        RegiUser.Password,
                        RegiUser.Email,
                        (userType)Enum.Parse(typeof(userType), RegiUser.UserType),
                        RegiUser.Birthday,
                        (genreType)Enum.Parse(typeof(genreType), RegiUser.FavGenre),
                        RegiUser.ProfilePictureName,
                        RegiUser.ProfilePictureData,
                        RegiUser.ProfilePictureContentType
                        );

                // validate if user already exists.It could go wrong
                // Change the naming for more functionaity 

                var result = _userManager.AddWEB(newUser);

                if (result.Success)
                {
                    return RedirectToPage("/Index");
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Something went wrong!" + ex.Message);

                return Page();
            }
        }
    }
}
