using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;

namespace Logic
{
    public class ProfileMapper
	{
		public static Profile ConvertToProfile(ProfileDTO profileDTO)
		{
			Profile profile = new Profile();

			profile.ProfileID = profileDTO.ProfileID;
			profile.User = UserMapper.ConvertToUser(profileDTO.UserDTO);
			profile.User_Balance = profileDTO.User_Balance;

			return profile;

		}

		public static ProfileDTO ConvertToProfileDTO(Profile profile)
		{
			ProfileDTO profileDTO = new ProfileDTO();
			profileDTO.ProfileID = profile.ProfileID;
			profileDTO.UserDTO = UserMapper.ConvertToUserDTO(profile.User);
			profileDTO.User_Balance = profile.User_Balance;

			return profileDTO;
		}
	}
}
