using Logic;
using Moq;
using Infrastructure;
    namespace UnitTestsMusicBoomBoxd
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public void AddUser_WhenValidUserProvided_Should_Add_User_To_The_List_And_Datbase()
        {
            // Arrange

            // Mocks for the IUserRepository and IValidateUser interfaces
            // To isolates the UserManager class from its dependencies which allows me to test it in isolation
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserValidation = new Mock<IValidateUser>();

            UserManager userManager = new UserManager(mockUserRepository.Object, mockUserValidation.Object);

            User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

            //I Mock the LoadUsersFromDataBase method to return a predefined list of users

            //this mocks the repository to return a successful result when InsertUser is called
            mockUserRepository.Setup(repo => repo.InsertUser(It.IsAny<UserDTO>())).Returns(new Result { Success = true });

            //this mocks the UserValidation to return false for username existence checks
            //It simulates that the username does not already exist in the system
            mockUserValidation.Setup(val => val.UsernameExists(It.IsAny<string>())).Returns(false);

            // Act

            //this calls the add method in the usermanger with the test user which triggers the logic I want to test 
            var result = userManager.Add(user);

            // Assert

            Assert.IsTrue(result.Success);
            //This Verify method checks that the InsertUser method of the repository mock was called exactly once +
            //with a UserDTO that has the same username as the test user
            //This makes sure the user was passed to the repository correctly.
            mockUserRepository.Verify(repo => repo.InsertUser(It.Is<UserDTO>(u => u.Username == user.Username)), Times.Once);
        }
    }
}