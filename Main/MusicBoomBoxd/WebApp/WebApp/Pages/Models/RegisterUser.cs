using Logic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[\\w\\-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$", ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Length(4, 100, ErrorMessage = "Password is too short")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        public userType UserType { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [PastDate(ErrorMessage = "Birthday cannot be today or a future date")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "FavGenre is required")]
        public genreType FavGenre { get; set; }

        public string ProfilePictureName { get; set; }

        public byte[] ProfilePictureData { get; set; }

        public string ProfilePictureContentType { get; set; }

        public RegisterUser()
        {

        }

        public RegisterUser(string name, string email, string password, userType userType, DateTime birthday, genreType favGenre, string profilePictureName, byte[] profilePictureData, string profilePictureContentType)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
            Birthday = birthday;
            FavGenre = favGenre;
            ProfilePictureName = profilePictureName;
            ProfilePictureData = profilePictureData;
            ProfilePictureContentType = profilePictureContentType;
        }
    }
}

