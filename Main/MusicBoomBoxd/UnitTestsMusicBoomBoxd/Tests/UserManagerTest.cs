using Logic;
using Infrastructure;
using UnitTestsMusicBoomBoxd.Mock;

namespace UnitTestsMusicBoomBoxd
{
    [TestClass]
    public class UserManagerTest
    {
		private List<UserDTO> mockUser;

		//This tests adding a valid user and checks if the user is added successfully.
		[TestMethod]
        public void AddUser_When_ValidUser_Provided_Should_Add_User_To_The_List_And_Database()
        {
			// Arrange
			// I  set up the mock repositories and other dependencies,
			// then create an instance of UserManager and a User object to be added.

			MockUserRepository userRepository = new MockUserRepository(mockUser);
			MockPasswordHasher passwordHasher = new MockPasswordHasher();
			MockValidateUser validateUser = new MockValidateUser();
			MockProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

			User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

			// Act
			// I call the AddUser method in the UserManage, passing the User object.
			Result result = userManager.Add(user);

			// Assert
			// I check if the result indicates success and contains the correct message.
			// Then, it retrieves the most recent user using the GetRecentUser method of MockUserRepository and verifys that the user details match the expected values.

			Assert.IsTrue(result.Success);
			Assert.AreEqual("User inserted successfully.", result.Message);

			var recentUsers = userRepository.GetRecentUser(1);
			Assert.AreEqual(1, recentUsers.Count);
			Assert.AreEqual("testuser", recentUsers[0].Username);
			Assert.AreEqual("test@example.com", recentUsers[0].Email);
		}


		//This tests adding a user with an existing username and expects an error message
		[TestMethod]
		public void AddUser_When_UsernameIsTaken_Should_Return_ErrorMessage()
		{
			// Arrange
			// I  set up the mock repositories and other dependencies,
			// then create an instance of UserManager and a User object to be added.

			MockUserRepository userRepository = new MockUserRepository(mockUser);
			MockPasswordHasher passwordHasher = new MockPasswordHasher();
			MockValidateUser validateUser = new MockValidateUser();
			MockProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

			User user = new User("existinguser", "password", "new@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");
			
			// Act
			Result result = userManager.Add(user);

			// Assert
			Assert.IsFalse(result.Success);
			Assert.AreEqual("Username is already taken", result.Message);
		}

		//This test retrieving a user by username and checks if the correct user is returned.
		[TestMethod]
		public void GetUser_When_UserExists_Should_Return_User()
		{
			// Arrange
			// I  set up the mock repositories and other dependencies,
			// then create an instance of UserManager and a User object to be added.

			MockUserRepository userRepository = new MockUserRepository(mockUser);
			MockPasswordHasher passwordHasher = new MockPasswordHasher();
			MockValidateUser validateUser = new MockValidateUser();
			MockProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

			User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

			Result result = userManager.Add(user);

			// Act
			UserDTO retrievedUser = userRepository.GetUserByUsername("testuser");

			// Assert
			Assert.IsNotNull(retrievedUser);
			Assert.AreEqual("testuser", retrievedUser.Username);
			Assert.AreEqual("test@example.com", retrievedUser.Email);

		}

		//This tests updating a user's email and verifies if the update is successful.
		[TestMethod]
		public void UpdateUser_When_ValidUser_Provided_Should_Update_User()
		{
			// Arrange
			// I  set up the mock repositories and other dependencies,
			// then create an instance of UserManager and a User object to be added.

			MockUserRepository userRepository = new MockUserRepository(mockUser);
			MockPasswordHasher passwordHasher = new MockPasswordHasher();
			MockValidateUser validateUser = new MockValidateUser();
			MockProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

			User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");
			
			userManager.Add(user);

			UserDTO userDTO = userRepository.GetUserByUsername("testuser");
			userDTO.Email = "updated@example.com";

			// Act
			Result result = userRepository.UpdateUser(userDTO);

			// Assert
			Assert.IsTrue(result.Success);
			Assert.AreEqual("User updated successfully.", result.Message);

			UserDTO updatedUser = userRepository.GetUserByUsername("testuser");
			Assert.AreEqual("updated@example.com", updatedUser.Email);

		}

		//This tests deleting an existing user and ensures the user is removed.
		[TestMethod]
		public void DeleteUser_When_UserExists_Should_Remove_User() 
		{

			// Arrange
			// I  set up the mock repositories and other dependencies,
			// then create an instance of UserManager and a User object to be added.

			MockUserRepository userRepository = new MockUserRepository(mockUser);
			MockPasswordHasher passwordHasher = new MockPasswordHasher();
			MockValidateUser validateUser = new MockValidateUser();
			MockProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

			User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");
			
			userManager.Add(user);

			UserDTO userDTO = userRepository.GetUserByUsername("testuser");

			// Act
			Result result = userRepository.DeleteUser(userDTO);

			// Assert
			Assert.IsTrue(result.Success);
			Assert.AreEqual("User removed successfully.", result.Message);

			UserDTO deletedUser = userRepository.GetUserByUsername("testuser");
			Assert.IsNull(deletedUser);

		}


	}
}