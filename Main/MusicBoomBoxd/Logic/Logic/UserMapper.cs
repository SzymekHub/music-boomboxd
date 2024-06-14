using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;


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
		}

		public static UserDTO ConvertToUserDTO(User user)
		{
            if (user == null)
            {
                return null;
            }
            // this converts User to UserDTO
            UserDTO userDTO = new();

			userDTO.UserID = user.UserID;
			userDTO.Username = user.Username;
			userDTO.Password = user.Password;
			userDTO.Email = user.Email;
			userDTO.UserType = user.UserType.ToString();
			userDTO.Birthday = user.Birthday;
			userDTO.FavGenre = user.FavGenre.ToString();
			userDTO.ProfilePictureName = user.ProfilePictureName;
			userDTO.ProfilePictureData = user.ProfilePictureData;
			userDTO.ProfilePictureContentType = user.ProfilePictureContentType;

			return userDTO;
		
		}
	}
}
