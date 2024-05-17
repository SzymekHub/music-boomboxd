using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Infrastructure;
using Logic;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserRepository _userRepository;
        public IndexModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        // i want ui to handle rules. And logic to validate. Introduce a class manager that validates user  

        public async Task<IActionResult> OnPostAsync()
        {
            var userDTO = _userRepository.GetUserByUsername(Username);

            if (userDTO != null && PasswordHasher.VerifyPassword(Password, userDTO.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Email, userDTO.Email.ToString()), // Use ClaimTypes.Email for email claim
                    // Add other claims as needed
                };

                // Create authentication cookie
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Customize authentication properties if needed
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);

                // Redirect to the profile page after successful login
                return RedirectToPage("/Profile");
            }

            // Display error message if username or password is incorrect
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
