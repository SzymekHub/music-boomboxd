using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public IActionResult OnPost()
        {
            if(Username == "admin" &&  Password == "admin")
            {
                return RedirectToPage("/HomePage");
            }
            else
            {
                return Page();
            }
        }
    }
}
