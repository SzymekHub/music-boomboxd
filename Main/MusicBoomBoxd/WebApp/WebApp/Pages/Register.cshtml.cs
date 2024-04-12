using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using WebApp.Models;
using Infrastructure.DTOs;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Models.User User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                UserDTO newUser = new UserDTO(User.UserName, User.Password, User.Email);

                if (userManager.SendToTheDb(newUser))
                {
                    return RedirectToPage("/Index");
                }
                return Page();
            }
            else
            { 
                return Page(); 
            }
        }
    }
}
