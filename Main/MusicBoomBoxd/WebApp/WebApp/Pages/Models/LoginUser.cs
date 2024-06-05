using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[\\w\\-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$", ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password is too short")]
        public string Password { get; set; }

        public LoginUser()
        {
        }

        public LoginUser(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
