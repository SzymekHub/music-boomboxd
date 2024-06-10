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
        public readonly UserManager _userManager;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IProfileRepository _profileRepository;
        public readonly IUserRepository _userRepository;
        private readonly IValidateUser _validateUsers;

        public IndexModel(IPasswordHasher passwordHasher, IUserRepository userRepository, IValidateUser validateUsers, IProfileRepository profileRepository)
        {
            _userManager = new UserManager(userRepository, profileRepository, validateUsers, passwordHasher);
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _validateUsers = validateUsers;
            _profileRepository = profileRepository;
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

            User user = _userManager.GetUserByUsernameFromDb(Username);

            if (user != null && _passwordHasher.VerifyPassword(Password, user.Password))
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
