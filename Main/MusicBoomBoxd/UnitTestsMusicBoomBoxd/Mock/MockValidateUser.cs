using Infrastructure;
using Infrastructure.DTOs;
using Infrastructure.InterfacesForRepo;
using Infrastructure.Repositories;
using Logic.Algorithms;
using Logic.Interfaces;
using Logic;


namespace UnitTestsMusicBoomBoxd.Mock
{
	public class MockValidateUser : IValidateUser
	{
		public Dictionary<string, List<string>> ValidateUsers(string username)
		{
			var errors = new Dictionary<string, List<string>>();
			if (username == "existinguser")
			{
				errors["username"] = new List<string> { "Username is already taken" };
			}
			return errors;
		}

		public Dictionary<string, List<string>> ValidateUsersWEB(User user)
		{
			var errors = new Dictionary<string, List<string>>();
			if (user.Username == "existinguser")
			{
				errors["username"] = new List<string> { "Username is already taken" };
			}
			if (user.Email == "existing@example.com")
			{
				errors["email"] = new List<string> { "Email is already taken" };
			}
			return errors;
		}

		public bool IsUsernameOrEmailTaken(string username, string email, int userId)
		{
			return (username == "existinguser" && userId != 1) || (email == "existing@example.com" && userId != 1);
		}

		public bool UsernameExists(string username)
		{
			return username == "existinguser";
		}

		public bool EmailExists(string email)
		{
			return email == "existing@example.com";
		}
	}
}