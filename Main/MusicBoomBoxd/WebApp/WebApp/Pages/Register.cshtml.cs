using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Infrastructure;
using Infrastructure.DTOs;
using WebApp.Models;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public RegisterModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public Models.User User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Perform input validation
                if (string.IsNullOrWhiteSpace(User.UserName) || string.IsNullOrWhiteSpace(User.Password) || string.IsNullOrWhiteSpace(User.Email))
                {
                    ModelState.AddModelError(string.Empty, "All fields are required.");
                    return Page();
                }

                try
                {
                    // Convert User to UserDTO
                    var userDTO = new Infrastructure.DTOs.UserDTO
                    {
                        UserName = User.UserName,
                        Password = User.Password,
                        Email = User.Email
                    };

                    // Attempt to insert user into the database
                    _userRepository.InsertUser(userDTO);

                    // Redirect to login page after successful registration
                    return new RedirectToPageResult("Login");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions and add model error
                    ModelState.AddModelError(string.Empty, $"User registration failed: {ex.Message}");
                    return Page();
                }
            }

            return Page();
        }
    }
}
