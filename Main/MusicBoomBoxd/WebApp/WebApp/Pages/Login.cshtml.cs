using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Infrastructure;
using Logic;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        public UserManager userManager { get; } 
        public LoginModel()
        {
            IUserRepository iuserRep = new UserRepository();
            IProfileRepository iprofileRep = new ProfileRepository();
            ValidateUser validateUsers = new ValidateUser(iuserRep);
            userManager = new UserManager(iuserRep, iprofileRep, validateUsers);
        }
        [BindProperty]
        public LoginUser Login { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        // i want ui to handle rules. And logic to validate. Introduce a class manager that validates user  

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/HomePage");
            }
            return Page();
        }

        public async  Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = userManager.GetUserByUsernameFromDb(Username);

            if (user != null && PasswordHasher.VerifyPassword(Password, user.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())

                };

                // Create authentication cookie
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Customize authentication properties if needed
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);

                // Redirect to the HomePage after successful login
                return RedirectToPage("/HomePage");
            }

            // Display error message if username or password is incorrect
            ViewData["ErrorMessage"] = "Invalid username or password";
            return Page();
        }
    }
}
