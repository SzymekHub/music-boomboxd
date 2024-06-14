using Infrastructure;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;


namespace UnitTestsMusicBoomBoxd.Mock
{
	public class MockPasswordHasher : IPasswordHasher
	{
		public string HashPassword(string password)
		{
			return password;
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			throw new NotImplementedException();
		}
	}
}
