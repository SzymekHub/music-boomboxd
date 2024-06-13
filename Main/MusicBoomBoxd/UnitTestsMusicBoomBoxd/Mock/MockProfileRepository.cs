using Infrastructure;
using Logic;

namespace UnitTestsMusicBoomBoxd.Mock
{
	public class MockProfileRepository : IProfileRepository
	{
		public Result InsertProfile(ProfileDTO profileDTO)
		{
			throw new NotImplementedException();
		}
		public Result AddProfileCritic(ProfileDTO profileDTO)
		{
			throw new NotImplementedException();
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
