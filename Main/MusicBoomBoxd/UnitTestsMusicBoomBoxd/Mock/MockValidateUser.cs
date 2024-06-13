using Logic;

namespace UnitTestsMusicBoomBoxd
{
	public class MockValidateUser : IValidateUser
	{
		public Dictionary<string, List<string>> ValidateUsers(string username)
		{
			throw new NotImplementedException();

		}

		public Dictionary<string, List<string>> ValidateUsersWEB(User user)
		{
			throw new NotImplementedException();

		}

		public bool IsUsernameOrEmailTaken(string username, string email, int userId)
		{
			throw new NotImplementedException();

		}

		public bool UsernameExists(string username)
		{
			throw new NotImplementedException();

		}

		public bool EmailExists(string email)
		{
			throw new NotImplementedException();

		}
	}
}
