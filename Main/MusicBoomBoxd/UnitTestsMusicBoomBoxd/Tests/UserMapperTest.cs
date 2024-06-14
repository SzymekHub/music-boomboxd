using Infrastructure.DTOs;
using Logic;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class UserMapperTest
    {
        // This tests converting from UserDTO to User (happy Scenario)
        [TestMethod]
        public void ConvertToUser_When_ValidUserDTO_Provided_Should_Return_User()
        {
            // Arrange
            var userDTO = new UserDTO
            {
                UserID = 1,
                Username = "testuser",
                Password = "password",
                Email = "test@example.com",
                UserType = "Regular",
                Birthday = DateTime.Now,
                FavGenre = "Metal",
                ProfilePictureName = "ProfilePicTest",
                ProfilePictureData = new byte[] { 1, 1, 1, 1 },
                ProfilePictureContentType = "JPG",
                Active = true
            };

            // Act
            var user = UserMapper.ConvertToUser(userDTO);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userDTO.UserID, user.UserID);
            Assert.AreEqual(userDTO.Username, user.Username);
            Assert.AreEqual(userDTO.Password, user.Password);
            Assert.AreEqual(userDTO.Email, user.Email);
            Assert.AreEqual(userDTO.UserType, user.UserType.ToString());
            Assert.AreEqual(userDTO.Birthday, user.Birthday);
            Assert.AreEqual(userDTO.FavGenre, user.FavGenre.ToString());
            Assert.AreEqual(userDTO.ProfilePictureName, user.ProfilePictureName);
            Assert.AreEqual(userDTO.ProfilePictureData, user.ProfilePictureData);
            Assert.AreEqual(userDTO.ProfilePictureContentType, user.ProfilePictureContentType);
        }

        // This tests converting from UserDTO to User (unhappy scenario)
        [TestMethod]
        public void ConvertToUser_When_NullUserDTO_Provided_Should_Return_Null()
        {
            // Arrange
            UserDTO userDTO = null;

            // Act
            var user = UserMapper.ConvertToUser(userDTO);

            // Assert
            Assert.IsNull(user);
        }

        // This tests converting from User to UserDTO (happy scenario)
        [TestMethod]
        public void ConvertToUserDTO_When_ValidUser_Provided_Should_Return_UserDTO()
        {
            // Arrange
            var user = new User(
                1,
                "testuser",
                "password",
                "test@example.com",
                userType.Regular,
                DateTime.Now,
                genreType.Metal,
                "ProfilePicTest",
                new byte[] { 1, 1, 1, 1 },
                "JPG"
            );

            // Act
            var userDTO = UserMapper.ConvertToUserDTO(user);

            // Assert
            Assert.IsNotNull(userDTO);
            Assert.AreEqual(user.UserID, userDTO.UserID);
            Assert.AreEqual(user.Username, userDTO.Username);
            Assert.AreEqual(user.Password, userDTO.Password);
            Assert.AreEqual(user.Email, userDTO.Email);
            Assert.AreEqual(user.UserType.ToString(), userDTO.UserType);
            Assert.AreEqual(user.Birthday, userDTO.Birthday);
            Assert.AreEqual(user.FavGenre.ToString(), userDTO.FavGenre);
            Assert.AreEqual(user.ProfilePictureName, userDTO.ProfilePictureName);
            Assert.AreEqual(user.ProfilePictureData, userDTO.ProfilePictureData);
            Assert.AreEqual(user.ProfilePictureContentType, userDTO.ProfilePictureContentType);
        }

        // This tests converting from User to UserDTO (unhappy scenario)
        [TestMethod]
        public void ConvertToUserDTO_When_NullUser_Provided_Should_Return_Null()
        {
            // Arrange
            User user = null;

            // Act
            var userDTO = UserMapper.ConvertToUserDTO(user);

            // Assert
            Assert.IsNull(userDTO);
        }
    }
}
