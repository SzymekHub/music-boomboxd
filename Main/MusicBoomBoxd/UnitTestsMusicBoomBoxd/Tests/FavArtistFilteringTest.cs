using Logic;
using Infrastructure.DTOs;
using Logic.Algorithms;
using UnitTestsMusicBoomBoxd.Mock;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class FavArtistFilteringTest
    {
        [TestMethod]
        public void GetFilteredAlbum_ShouldReturnAlbums_ForFavoriteArtists()
        {
            //Arrange
            User user = new User(1, "testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");

            var mockUserFavArtist = new List<KeyValuePair<int, int>>();

            //first 1 is user and second one is artisID
            mockUserFavArtist.Add(new (1, 1));
            mockUserFavArtist.Add(new(1, 2));

            var mockArtist = new List<ArtistDTO>
            {
                new ArtistDTO
                {
                    Active = true,
                    ArtistID = 1,
                    Name = "Favorite Artist",
                    ArtistPictureName = "ArtistProfilePic",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG"
                },
                 new ArtistDTO
                {
                    Active = true,
                    ArtistID = 2,
                    Name = "Favorite Artist 2",
                    ArtistPictureName = "ArtistProfilePic",
                    ArtistPictureData = new byte[] { 1, 1, 1, 1 },
                    ArtistPictureContentType = "JPG"
                }
            };
            var mockAlbums = new List<AlbumDTO>
            {
                new AlbumDTO { AlbumID = 1, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 1, Name = "Favorite Artist", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 1", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rock.ToString(), AlbumCoverName = "AlbumCover1", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG" },
                new AlbumDTO { AlbumID = 2, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 2, Name = "Favorite Artist 2", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 2", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rock.ToString(), AlbumCoverName = "AlbumCover2", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG"  },
                new AlbumDTO { AlbumID = 3, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 3, Name = "Favorite Artist 3", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 3", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rock.ToString(), AlbumCoverName = "AlbumCover3", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG"  }
            };

            MockProfileRepository mockProfileRepository = new MockProfileRepository(new ProfileDTO(), 666.00);
            MockAlbumRepository mockAlbumRepository = new MockAlbumRepository(mockAlbums);
            MockArtistRepository mockArtistRepository = new MockArtistRepository(mockArtist, mockUserFavArtist);
            FavArtistFilter favArtistFilter = new FavArtistFilter(mockAlbumRepository, mockArtistRepository);

            //Act
            List<Album> filteredAlbums = favArtistFilter.GetFilteredAlbum(user);

            //Assert
            Assert.AreEqual(2, filteredAlbums.Count);
            Assert.IsTrue(filteredAlbums.Any(album => album.AlbumID == 1));
            Assert.IsTrue(filteredAlbums.Any(album => album.AlbumID == 2));
        }
    }
}
