using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username is too short")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[\\w\\-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$", ErrorMessage = "Email invalid")]
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
        public string ProfilePictureName { get; set; }

        [Required(ErrorMessage = "Profile Picture is required")]
        public byte[] ProfilePictureData { get; set; }

        [Required(ErrorMessage = "Profile Picture Content Type is required")]
        public string ProfilePictureContentType { get; set; }
    }
}
