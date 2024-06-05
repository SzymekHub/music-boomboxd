using Infrastructure;

namespace Logic
{
    public class ProfileManager
    {
        private readonly IProfileRepository profileRepository;

        public ProfileManager(IProfileRepository iProfRep)
        {
            profileRepository = iProfRep;
        }

        public double GetBalance(string userName)
        {
            return profileRepository.GetBalance(userName);
        }

        public int GetProfileIDByUsername(string userName)
        {
            return profileRepository.GetProfileIDByUsername(userName);
        }

        public Result AddProfileCritic(Profile profile)
        {
            ProfileDTO profileDTO = ConvertToProfileDTO(profile);
            Result result = profileRepository.AddProfileCritic(profileDTO);

            return result;
        }
        public Result AddProfileMusician(Profile profile)
        {
            ProfileDTO profileDTO = ConvertToProfileDTO(profile);
            Result result = profileRepository.AddProfileMusician(profileDTO);

            return result;
        }

        public static Profile ConvertToProfile(ProfileDTO profileDTO)
        {
            return new Profile(
                    profileDTO.ProfileID,
                    profileDTO.UserID,
                    profileDTO.User_Balance
                );
        }
        public static ProfileDTO ConvertToProfileDTO(Profile profile)
        {
            ProfileDTO profileDTO = new ProfileDTO();
            profileDTO.ProfileID = profile.ProfileID;
            profileDTO.UserID = profile.UserID;
            profileDTO.User_Balance = profile.User_Balance;

            return profileDTO;
        }
    }
}
