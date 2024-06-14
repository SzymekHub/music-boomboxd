using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
    public class MockProfileRepository : IProfileRepository
	{
		private readonly double _mockUserBalance;
		private readonly ProfileDTO _mockProfile;

        public MockProfileRepository(ProfileDTO mockProfile, double mockUserBalance)
        {
            _mockProfile = mockProfile;
			_mockUserBalance = mockUserBalance;
        }

        public Result InsertProfile(ProfileDTO profileDTO)
		{
			int newProfileID = _mockProfile.ProfileID + 1;
			profileDTO.ProfileID = newProfileID;

			_mockProfile.ProfileID = newProfileID;
			
			return new Result { Success = true };
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
