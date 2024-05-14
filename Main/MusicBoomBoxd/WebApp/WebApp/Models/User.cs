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
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password is too short")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "FavGenre is required")]
        public string FavGenre { get; set; }

        [Required(ErrorMessage = "ProfilePicture is required")]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureName { get; set; }

        [Required(ErrorMessage = "Profile Picture is required")]
        public byte[] ProfilePictureData { get; set; }

        [Required(ErrorMessage = "Profile Picture Content Type is required")]
        public string ProfilePictureContentType { get; set; }

        public User(string userName, string password, string email, string userType, DateTime birthday, string favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
        {
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
            Birthday = birthday;
            FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
        }
    }
}
