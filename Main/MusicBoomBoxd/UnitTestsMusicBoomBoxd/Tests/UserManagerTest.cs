using Logic;
using Infrastructure;
using UnitTestsMusicBoomBoxd.Mock;
namespace UnitTestsMusicBoomBoxd
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public void AddUser_When_ValidUser_Provided_Should_Add_User_To_The_List_And_Datbase()
        {
			// Arrange
			IUserRepository userRepository = new MockUserRepository();
            IPasswordHasher passwordHasher = new MockPasswordHasher();
            IValidateUser validateUser = new MockValidateUser();
            IProfileRepository profileRepository = new MockProfileRepository();

			UserManager userManager = new UserManager(passwordHasher, userRepository, validateUser, profileRepository);

            User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

            //Act

            
        }
    }
}