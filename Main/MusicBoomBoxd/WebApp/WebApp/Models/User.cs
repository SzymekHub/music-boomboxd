using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Length(4, 100, ErrorMessage = "Password is too short")]
        public string Password { get; set; }

        public User() 
        { 
        }

        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
