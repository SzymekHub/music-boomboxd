using Infrastructure.DTOs;
using Logic;
using Logic.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsMusicBoomBoxd.Mock;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class ReviewFilteringTest
    {
        [TestMethod]
        public void GetFilteredAlbums_ReturnsAlbumsBasedOnSimilarUsersRatings()
        {
            // Arrange
            User user = new User(1, "testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

            var mockReviews = new List<ReviewDTO>
            {
                new ReviewDTO { UserDTO = new UserDTO { UserID = 2 }, AlbumDTO = new AlbumDTO { AlbumID = 1 }, Rate = 5 },
                new ReviewDTO { UserDTO = new UserDTO { UserID = 2 }, AlbumDTO = new AlbumDTO { AlbumID = 2 }, Rate = 4 },
                new ReviewDTO { UserDTO = new UserDTO { UserID = 1 }, AlbumDTO = new AlbumDTO { AlbumID = 1 }, Rate = 5 },
                new ReviewDTO { UserDTO = new UserDTO { UserID = 3 }, AlbumDTO = new AlbumDTO { AlbumID = 4 }, Rate = 4 },
                new ReviewDTO { UserDTO = new UserDTO { UserID = 1 }, AlbumDTO = new AlbumDTO { AlbumID = 5 }, Rate = 3 }
            };

            var mockAlbums = new List<AlbumDTO>
            {
                new AlbumDTO { AlbumID = 1, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 1, Name = "Favorite Artist", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 1", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rock.ToString(), AlbumCoverName = "AlbumCover1", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG" },
                new AlbumDTO { AlbumID = 2, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 2, Name = "Favorite Artist 2", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 2", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rock.ToString(), AlbumCoverName = "AlbumCover2", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG"  },
            };

            MockReviewRepository mockReviewRepository = new MockReviewRepository(mockReviews);
            MockAlbumRepository mockAlbumRepository = new MockAlbumRepository(mockAlbums);
            ReviewFilter reviewFilter = new ReviewFilter(mockReviewRepository, mockAlbumRepository);

            // Act
            List<Album> filteredAlbums = reviewFilter.GetFilteredAlbum(user);

            // Assert
            Assert.AreEqual(2, filteredAlbums.Count);
            Assert.IsTrue(filteredAlbums.Any(stock => stock.AlbumID == 1));
            Assert.IsTrue(filteredAlbums.Any(stock => stock.AlbumID == 2));
        }
    }
}
