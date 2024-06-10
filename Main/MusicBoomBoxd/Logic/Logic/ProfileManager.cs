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

        public Result AddToUserBalance(string userName, double amount)
        {
            int profileID = profileRepository.GetProfileIDByUsername(userName);
            return profileRepository.AddToUserBalance(profileID, amount);
        }

        public int GetProfileIDByUsername(string userName)
        {
            return profileRepository.GetProfileIDByUsername(userName);
        }

        public Result AddProfileCritic(Profile profile)
        {
            ProfileDTO profileDTO = ProfileMapper.ConvertToProfileDTO(profile);
            Result result = profileRepository.AddProfileCritic(profileDTO);

            return result;
        }
        public Result AddProfileMusician(Profile profile)
        {
            ProfileDTO profileDTO = ProfileMapper.ConvertToProfileDTO(profile);
            Result result = profileRepository.AddProfileMusician(profileDTO);

            return result;
        }
    }
}
