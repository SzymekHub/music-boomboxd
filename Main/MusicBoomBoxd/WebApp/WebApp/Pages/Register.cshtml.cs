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
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                bool registrationSuccess = _userLogic.RegisterUser(Input.UserName, Input.Password, Input.Email);

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
