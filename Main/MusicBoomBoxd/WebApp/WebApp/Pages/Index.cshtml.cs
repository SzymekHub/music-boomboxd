using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Infrastructure;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbConnection _dbConnection;

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel()
        {
            _dbConnection = new DbConnection();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Hardcoded Login credentials.
            if (UserName == "Admin" && Password == "P")
            {
                // this code to create authentication cookie with claims here
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, UserName));
                claims.Add(new Claim("id", "1"));

                //Creation of authetication cookie
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/HomePage");
            }

            // Display error message if username or password is empty or incorrect
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
