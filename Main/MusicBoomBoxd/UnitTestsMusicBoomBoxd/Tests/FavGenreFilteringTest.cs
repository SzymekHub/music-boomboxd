using Infrastructure.DTOs;
using Logic.Algorithms;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsMusicBoomBoxd.Mock;

namespace UnitTestsMusicBoomBoxd.Tests
{
    [TestClass]
    public class FavGenreFilteringTest
    {

        [TestMethod]
        public void GetFilteredAlbum_ShouldReturnAlbums_ForFavoriteGenre()
        {
            //Arrange
            User user = new User(1, "testuser", "password", "test@example.com", userType.Regular, DateTime.Now, genreType.Metal, "ProfilePicTest", new byte[] { 1, 1, 1, 1 }, "JPG");
           
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

            var mockGenre = new List<genreType>
            {
             genreType.Rap,
             genreType.Metal,
             genreType.Reggae,
             genreType.Blues,
             genreType.Techno
            };
            var mockAlbums = new List<AlbumDTO>
            {
                new AlbumDTO { AlbumID = 1, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 1, Name = "Favorite Artist", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 1", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Metal.ToString(), AlbumCoverName = "AlbumCover1", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG" },
                new AlbumDTO { AlbumID = 2, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 2, Name = "Favorite Artist 2", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 2", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Rap.ToString(), AlbumCoverName = "AlbumCover2", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG"  },
                new AlbumDTO { AlbumID = 3, ArtistDTO = new ArtistDTO { Active = true, ArtistID = 3, Name = "Favorite Artist 3", ArtistPictureName = "ArtistProfilePic", ArtistPictureData = new byte[] { 1, 1, 1, 1 }, ArtistPictureContentType = "JPG" }, AlbumTitle = "Album 3", ReleaseDate =DateTime.Now, RunTime = 222, Genre = genreType.Metal.ToString(), AlbumCoverName = "AlbumCover3", AlbumCoverData = new byte[] { 1, 1, 1, 1 }, AlbumCoverContentType = "JPG"  }
            };

            MockProfileRepository mockProfileRepository = new MockProfileRepository(new ProfileDTO(), 666.00);
            MockAlbumRepository mockAlbumRepository = new MockAlbumRepository(mockAlbums);
            MockArtistRepository mockArtistRepository = new MockArtistRepository(mockArtist, new());
            FavGenreFilter favGenreFilter = new FavGenreFilter(mockAlbumRepository);

            //Act
            List<Album> filteredAlbums = favGenreFilter.GetFilteredAlbum(user);

            //Assert
            Assert.AreEqual(2, filteredAlbums.Count);
            Assert.IsTrue(filteredAlbums.Any(album => album.AlbumID == 1));
            Assert.IsTrue(filteredAlbums.Any(album => album.AlbumID == 3));
        }
    }
}
