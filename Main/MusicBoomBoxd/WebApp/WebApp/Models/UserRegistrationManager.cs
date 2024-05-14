using Logic;
using Infrastructure.DTOs;

namespace WebApp.Models
{
    public class UserRegistrationManager
    {
        private readonly UserManager _userManager;

        public UserRegistrationManager(UserManager userManager)
        {
            _userManager = userManager;
        }

        public bool RegisterNewUser(User user)
        {
            // Convert Models.User to UserDTO
            var newUser = new UserDTO(
                user.UserName,
                user.Password,
                user.Email,
                user.UserType,
                user.Birthday,
                user.FavGenre,
                user.ProfilePictureName,
                user.ProfilePictureData,
                user.ProfilePictureContentType
            );

            // Send user registration request to UserManager
            return _userManager.SendToTheDb(newUser);
        }
    }
}
