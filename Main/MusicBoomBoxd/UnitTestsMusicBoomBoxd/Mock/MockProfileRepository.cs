using Infrastructure;
using Logic;

namespace UnitTestsMusicBoomBoxd.Mock
{
	public class MockProfileRepository : IProfileRepository
	{
		private Dictionary<int, ProfileDTO> profiles = new();

		public Result InsertProfile(ProfileDTO profileDTO)
		{
			profiles.Add(profileDTO.ProfileID, profileDTO);
			return new Result { Success = true, Message = "Profile created successfully" };
		}
		public Result AddProfileCritic(ProfileDTO profileDTO)
		{
			profiles.Add(profileDTO.UserDTO.UserID, profileDTO);
			return new Result { Success = true, };
		}
		public Result AddProfileMusician(ProfileDTO profileDTO)
		{
			throw new NotImplementedException();
		}
		public ProfileDTO GetProfileDTOForUser(int userID)
		{
			throw new NotImplementedException();
		}
		public double GetBalance(string userName)
		{
			throw new NotImplementedException();
		}
		public Result AddToUserBalance(int profileId, double amount)
		{
			throw new NotImplementedException();
		}
		public int GetProfileIDByUsername(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
