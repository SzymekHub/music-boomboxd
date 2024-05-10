using Infrastructure.DTOs;
using Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic
{
    public class ProfileManager
    {
        private readonly ProfileRepostiory _profileRepository;

        public ProfileManager(ProfileRepostiory profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Profiles GetProfileByEmail(string email)
        {
            // Retrieves the profile data for the given email from the repository
            ProfileDTO profileDTO = _profileRepository.GetProfileByEmail(email);
            return ConvertToProfile(profileDTO);
        }

        public void UpdateProfile(Profiles profile)
        {
            // Converts Profile object to ProfileDTO object
            ProfileDTO profileDTO = ConvertToProfileDTO(profile, profile.UserId);

            // Updates the profile data
            _profileRepository.UpdateProfile(profileDTO);
        }

        private Profiles ConvertToProfile(ProfileDTO profileDTO)
        {
            return new Profiles
            {
                UserId = profileDTO.UserId,
                Username = profileDTO.Username,
                Email = profileDTO.Email,
                Bio = profileDTO.Bio
            };
        }

        private ProfileDTO ConvertToProfileDTO(Profiles profile, int userId)
        {
            return new ProfileDTO(userId, profile.Username, profile.Email, profile.Bio);
        }
    }
}