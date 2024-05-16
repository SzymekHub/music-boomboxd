using Logic;
using Moq;
using Infrastructure;
using System;
namespace UnitTestsMusicBoomBoxd
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public void AddUser_WhenValidUserProvided_Should_Add_User_To_The_List_And_Datbase()
        {
            //Arrange
            var mockUserRepository = new Mock<UserRepository>();
            var mockLoadUsers = new Mock<LoadUsers>(mockUserRepository.Object);

            UserManager userManager = new UserManager(mockLoadUsers.Object);
            
            User user = new User("testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] {1,1,1,1}, "JPG");

            // Act
            userManager.Add(user);

            // Assert
            User[] users = userManager.GetArray();
            Assert.IsTrue(users.Length == 1);
            Assert.AreEqual(users[0], user);
        }
    }
}