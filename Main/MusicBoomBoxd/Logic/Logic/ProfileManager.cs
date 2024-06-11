using Infrastructure;

namespace Logic
{
	public class ProfileManager
	{
		private readonly IProfileRepository _profileRepository;
		private readonly IUserRepository _userRepository;
		private readonly IValidateUser _validateUser;
		private readonly IPasswordHasher _passwordHasher;
		private readonly UserManager _userManager;

		public ProfileManager(IProfileRepository iProfRep, IUserRepository iUserRep, IValidateUser ivalUser, IPasswordHasher IpassHash)
		{
			_profileRepository = iProfRep;
			_userRepository = iUserRep;
			_validateUser = ivalUser;
			_passwordHasher = IpassHash;
			_userManager = new UserManager(iUserRep, iProfRep, ivalUser, IpassHash);
		}


		public double GetBalance(string userName)
		{
			return _profileRepository.GetBalance(userName);
		}

		public Profile GetProfileForUser(int userID)
		{
			ProfileDTO profileDTO = _profileRepository.GetProfileDTOForUser(userID);

			Profile profile = ProfileMapper.ConvertToProfile(profileDTO);

			return profile;
		}
		public Result AddToUserBalance(string userName, double amount)
		{
			int profileID = _profileRepository.GetProfileIDByUsername(userName);
			return _profileRepository.AddToUserBalance(profileID, amount);
		}

		public int GetProfileIDByUsername(string userName)
		{
			return _profileRepository.GetProfileIDByUsername(userName);
		}

		public Result AddProfileCritic(Profile profile)
		{
			ProfileDTO profileDTO = ProfileMapper.ConvertToProfileDTO(profile);
			Result result = _profileRepository.AddProfileCritic(profileDTO);

			return result;
		}
		public Result AddProfileMusician(Profile profile)
		{
			ProfileDTO profileDTO = ProfileMapper.ConvertToProfileDTO(profile);
			Result result = _profileRepository.AddProfileMusician(profileDTO);

			return result;
		}
	}
}
