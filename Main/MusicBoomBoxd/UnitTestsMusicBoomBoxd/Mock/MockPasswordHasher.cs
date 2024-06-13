using Logic;

namespace UnitTestsMusicBoomBoxd
{
	public class MockPasswordHasher : IPasswordHasher
	{
		public string HashPassword(string password)
		{
			return "MockedHashPass";
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			return password == "MockPassword" && hashedPassword == "MockedHashPass";
		}
	}
}
