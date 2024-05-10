using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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

        [Required(ErrorMessage = "UserType is required")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "FavGenre is required")]
        public string FavGenre { get; set; }

        [Required(ErrorMessage = "ProfilePicture is required")]
        
        [Display(Name = "Profile Picture")]
        public string ProfilePictureName { get; set; }

        [Required(ErrorMessage = "Profile Picture is required")]
        public byte[] ProfilePictureData { get; set; }

        [Required(ErrorMessage = "Profile Picture Content Type is required")]
        public string ProfilePictureContentType { get; set; }


        public User() 
        { 
        }

        public User(string userName, string email, string password, string userType, string birthday, string favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.UserType = userType;
            this.Birthday = birthday;
            this.FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
        }
    }
}
