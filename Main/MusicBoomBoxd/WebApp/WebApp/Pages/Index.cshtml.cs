using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbConnection _dbConnection;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IActionResult OnPost()
        {
            //Hardcoded Login credentials.
            if (Username == "Admin" && Password == "P")
            { 
                return RedirectToPage("/HomePage");
            }
            else if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                if (_dbConnection.AuthenticateUser(Username, Password))
                {
                    return RedirectToPage("/HomePage");
                }
            }
            // Display error message if username or password is empty or incorrect
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
