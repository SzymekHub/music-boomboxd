using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserLogic _userLogic;

        public RegisterModel(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [BindProperty]
        public User Input { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            // Validate user input (e.g., check for duplicate usernames, password strength, etc.)
            if (string.IsNullOrWhiteSpace(Input.UserName) || string.IsNullOrWhiteSpace(Input.Password) || string.IsNullOrWhiteSpace(Input.Email))
            {
                // Input validation failed
                return Page();
            }
            
            // Attempt to register the user
            
            bool registrationSuccess = _userLogic.RegisterUser(Input.UserName, Input.Password, Input.Email);
            
            if (ModelState.IsValid)
            {
               
                if (registrationSuccess)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User registration failed. Please check your input.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
