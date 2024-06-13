using Logic;
using System.Collections.Generic;

namespace UnitTestsMusicBoomBoxd
{
	[TestClass]
	public class PasswordhasherTest
	{
		//Happy scenarios
		[TestMethod]
		public void HashPassword_Has_To_Return_Hashed_Password()
		{
			//Arrange 
			IPasswordHasher hasher = new MockPasswordHasher();
			string password = "MockPassword";

			//Act
			string hashedPassword = hasher.HashPassword(password);

			//Assert
			Assert.IsFalse(string.IsNullOrEmpty(hashedPassword));
			Assert.AreNotEqual(password, hashedPassword);
		}

		[TestMethod]
		public void Verify_Password_Should_Return_True_For_Correct_Password()
		{
			//Arrange
			IPasswordHasher hasher = new MockPasswordHasher();
			string password = "MockPassword";
			string hashedPassword = hasher.HashPassword(password);
			

			//Act
			bool result = hasher.VerifyPassword(password, hashedPassword);

			//Assert
			Assert.IsTrue(result);
		}

		//Unhappy scenario
		[TestMethod]
		public void Verify_Password_Should_Return_False_For_Incorrect_Password()
		{
			//Arrange
			IPasswordHasher hasher= new MockPasswordHasher();
			string password = "MockPassword";
			string hashedPassword = hasher.HashPassword(password);

			//Act
			bool result = hasher.VerifyPassword("WrongPassword", hashedPassword);

			//Assert
			Assert.IsFalse(result);
		}

	}
}
