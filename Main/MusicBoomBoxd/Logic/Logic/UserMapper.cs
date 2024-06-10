using Infrastructure;
using Logic;


namespace Logic
{
    public static class UserMapper
    {
        public static User ConvertToUser(UserDTO newUserDTO)
        {
            if (newUserDTO == null)
            {
                return null;
            }

            //Converts the user role enum to a string
            userType type = (userType)Enum.Parse(typeof(userType), newUserDTO.UserType);

            //Converts the genre enum to a string 
            genreType genre = (genreType)Enum.Parse(typeof(genreType), newUserDTO.FavGenre);

            //this converts UserDto to users
            return new User(
                newUserDTO.UserID,
                newUserDTO.Username,
                newUserDTO.Password,
                newUserDTO.Email,
                type,
                newUserDTO.Birthday,
                genre,
                newUserDTO.ProfilePictureName,
                newUserDTO.ProfilePictureData,
                newUserDTO.ProfilePictureContentType
                );

            //try and use a tryparse
        }

        public static UserDTO ConvertToUserDTO(User user)
        {
            // this converts User to UserDTO
            return new UserDTO(
                user.UserID,
                user.Username,
                user.Password,
                user.Email,
                user.UserType.ToString(),
                user.Birthday,
                user.FavGenre.ToString(),
                user.ProfilePictureName,
                user.ProfilePictureData,
                user.ProfilePictureContentType
                );
        }
    }
}
