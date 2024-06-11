using Infrastructure;

namespace Logic
{
    public class ProfileMapper
    {
		public static Profile ConvertToProfile(ProfileDTO profileDTO)
		{
            return new Profile(
                profileDTO.ProfileID,
                UserMapper.ConvertToUser(profileDTO.UserDTO),
                profileDTO.User_Balance
                );
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
