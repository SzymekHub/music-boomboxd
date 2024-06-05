using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Infrastructure;
using Logic;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public UserManager userManager { get; }

        public IndexModel()
        {
            IUserRepository iuserRep = new UserRepository();
            ValidateUser validateUsers = new ValidateUser(iuserRep);
            userManager = new UserManager(iuserRep, validateUsers);
        }

        [BindProperty]
        public LoginUser Login { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        // i want ui to handle rules. And logic to validate. Introduce a class manager that validates user  

        public async  Task<IActionResult> OnPostAsync()
        {
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
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
